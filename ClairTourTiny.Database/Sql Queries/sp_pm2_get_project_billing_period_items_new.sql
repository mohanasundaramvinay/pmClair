CREATE PROCEDURE [dbo].[pm2_get_project_billing_period_items_new]
    @entityno varchar(50)
AS
BEGIN
    WITH BillingItemsWithParentData AS (
        SELECT 
            pbi.bid_entityno,
            pbi.itemno,
            pbi.NominalDailyRate,
            -- Get IsFixedExpense from pjjobexpenses
            CASE 
                WHEN pje.period_type IN ('S', 'F') THEN 1 
                ELSE 0 
            END as IsFixedExpense,
            -- Calculate benchmarkDollars from NominalDailyRate
            pbi.NominalDailyRate * 7 as benchmarkDollars,
            pbi.expense_entityno,
            pbi.expense_seqno
        FROM dbo.ProjectBillingItems pbi
        LEFT JOIN dbo.pjjobexpenses pje 
            ON pbi.expense_entityno = pje.entityno 
            AND pbi.expense_seqno = pje.seqno
        WHERE pbi.bid_entityno = @entityno 
            OR pbi.bid_entityno LIKE @entityno + '-%'
    )
    SELECT 
        pbpi.bid_entityno,
        pbpi.periodno,
        pbpi.itemno,
        pbpi.StartDate,
        pbpi.EndDate,
        pbpi.ActualDailyRate,
        IsActive = pbpi.status,
        pbpi.billingDays,
        -- Computed fields
        Days = DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1,
        ActiveActualDailyRate = CASE 
            WHEN pbpi.status = 1 AND pbp.isActive = 1 THEN pbpi.ActualDailyRate 
            ELSE 0 
        END,
        ActiveActualDays = CASE 
            WHEN pbpi.status = 1 AND pbp.isActive = 1 THEN ISNULL(pbpi.billingDays, DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1)
            ELSE 0 
        END,
        ActiveActualValue = CASE 
            WHEN pbpi.status = 1 AND pbp.isActive = 1 
            THEN pbpi.ActualDailyRate * ISNULL(pbpi.billingDays, DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1)
            ELSE 0 
        END,
        ActivePeriodDays = CASE 
            WHEN pbpi.status = 1 AND pbp.isActive = 1 
            THEN DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1
            ELSE 0 
        END,
        Rate = CASE 
            WHEN ISNULL(bi.NominalDailyRate, 0) = 0 THEN 100 
            ELSE 100 * (pbpi.ActualDailyRate / bi.NominalDailyRate)
        END,
        PeriodTotal = ISNULL(pbpi.billingDays, DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1) * pbpi.ActualDailyRate,
        benchmarkDollars = ISNULL(bi.benchmarkDollars, 0),
        IsFixedExpense = ISNULL(bi.IsFixedExpense, 0),
        BenchmarkTotal = ISNULL(bi.benchmarkDollars * (DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1) / 7, 0),
        MarkupPct = CASE 
            WHEN ISNULL(bi.benchmarkDollars, 0) = 0 THEN 100 
            ELSE 100 * ((bi.NominalDailyRate * 7 / NULLIF(bi.benchmarkDollars, 0)) - 1)
        END,
        BenchmarkVariancePct = CASE 
            WHEN ISNULL(bi.benchmarkDollars * (DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1) / 7, 0) = 0 THEN 0 
            ELSE ((ISNULL(pbpi.billingDays, DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1) * pbpi.ActualDailyRate / 
                   NULLIF(bi.benchmarkDollars * (DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1) / 7, 0)) - 1) * 100
        END,
        BenchmarkVarianceDollars = (ISNULL(pbpi.billingDays, DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1) * pbpi.ActualDailyRate) - 
                                   ISNULL(bi.benchmarkDollars * (DATEDIFF(day, pbpi.StartDate, pbpi.EndDate) + 1) / 7, 0),
        adjustedWeekly = bi.NominalDailyRate * 7,
        adjustedDaily = bi.NominalDailyRate,
        -- Additional columns from view
        pbpi.crew_seqno as CrewSeqNo,
        pbpi.expense_entityno as ExpenseEntityNo,
        pbpi.category,
        pbpi.expense_seqno as ExpenseSeqNo,
        pbpi.crew_entityno as CrewEntityNo,
        pbpi.equipment_entityno as EquipmentEntityNo
    FROM dbo.pm2_get_project_billing_period_items_v pbpi
    INNER JOIN dbo.ProjectBillingPeriods pbp 
        ON pbpi.bid_entityno = pbp.bid_entityno 
        AND pbpi.periodno = pbp.periodno
    LEFT JOIN BillingItemsWithParentData bi 
        ON pbpi.bid_entityno = bi.bid_entityno 
        AND pbpi.itemno = bi.itemno
    WHERE pbpi.bid_entityno = @entityno 
        OR pbpi.bid_entityno LIKE @entityno + '-%'
    ORDER BY 
        pbpi.bid_entityno,
        pbpi.periodno,
        pbpi.crew_seqno ASC,
        pbpi.expense_entityno,
        pbpi.category DESC,
        pbpi.expense_seqno,
        pbpi.crew_entityno,
        pbpi.equipment_entityno,
        pbpi.itemno
END