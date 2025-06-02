CREATE procedure dbo.pm2_get_equipment_new
    @entityno varchar(50)
as
WITH DemandsByDate AS (
    -- Get all demands for each part grouped by date
    SELECT 
        t.partno,
        t.bld,
        t.fromdate,
        SUM(t.cumulative_qty) as total_demand
    FROM dbo.merged_job_budgets_parts_transactions_tbl t
    GROUP BY t.partno, t.bld, t.fromdate
),
FirstWeekDemand AS (
    -- Calculate maximum demand in first week for each part
    SELECT 
        e.partno,
        p.agency,
        MAX(CASE WHEN d.fromdate = e.trandate THEN d.total_demand ELSE 0 END) as day_of_demand,
        MAX(CASE WHEN d.fromdate BETWEEN e.trandate AND DATEADD(day, 6, e.trandate) 
            THEN d.total_demand ELSE 0 END) as week_of_demand
    FROM dbo.pjjobbudexp e
    JOIN dbo.glentities p ON e.entityno = p.entityno
    LEFT JOIN DemandsByDate d ON e.partno = d.partno AND p.agency = d.bld
    WHERE e.entityno = @entityno OR e.entityno LIKE @entityno + '-%'
    GROUP BY e.partno, p.agency
)

SELECT 
    e.entityno, 
    e.seqno, 
    PartDescription = i.partdesc, 
    e.partno, 
    StartDate = e.trandate, 
    EndDate = e.todate,
    UnitPrice = e.est_unit_amount, 
    Quantity = e.est_qty, 
    e.mfg_no, 
    Notes = e.mfg_desc,
    -- Original Bottleneck calculation
    Bottleneck = ISNULL(wpq.totalqty, 0) - MAX(ISNULL(t.cumulative_qty, 0)),
    -- Day Of Bottleneck (Bottleneck1d)
    Bottleneck1d = ISNULL(wpq.totalqty, 0) - ISNULL(fd.day_of_demand, 0),
    -- Week Of Bottleneck (Bottleneck1w)
    Bottleneck1w = ISNULL(wpq.totalqty, 0) - ISNULL(fd.week_of_demand, 0),
    CheckedOut = e.line_no,
    e.markup,
    e.QuantityToSubhire,
    Category = i.commmodity,
    e.NoteInternal,
    e.PriceLevelValue,
    totmatcost4 = i.RentalValueUSD,
    e.matrixcd
FROM dbo.pjjobbudexp e
JOIN dbo.inpart i ON e.partno = i.partno
JOIN dbo.glentities p ON e.entityno = p.entityno
LEFT OUTER JOIN dbo.warehouse_part_qty wpq WITH (NOEXPAND) 
    ON e.partno = wpq.partno AND wpq.bld = p.agency
LEFT OUTER JOIN dbo.merged_job_budgets_parts_transactions_tbl t 
    ON e.partno = t.partno
    AND t.bld = p.agency 
    AND t.fromdate <= e.todate
    AND ISNULL(t.todate, e.todate) >= e.trandate
LEFT OUTER JOIN FirstWeekDemand fd 
    ON e.partno = fd.partno 
    AND p.agency = fd.agency
WHERE e.entityno = @entityno OR e.entityno LIKE @entityno + '-%'
GROUP BY 
    e.entityno, e.seqno, i.partdesc, e.partno, e.trandate, e.todate, 
    e.est_unit_amount, e.est_qty, e.mfg_no, e.mfg_desc, wpq.totalqty,
    e.line_no, e.markup, e.QuantityToSubhire, i.commmodity, e.NoteInternal,
    e.PriceLevelValue, i.RentalValueUSD, e.matrixcd,
    fd.day_of_demand, fd.week_of_demand
ORDER BY e.entityno, e.seqno, e.partno