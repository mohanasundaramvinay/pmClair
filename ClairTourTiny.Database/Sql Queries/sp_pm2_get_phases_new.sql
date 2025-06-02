Create PROCEDURE [dbo].[pm2_get_phases_new] 
    @entityno VARCHAR(50)  
AS  
WITH EquipmentTotals AS (
    SELECT 
        e.entityno,
        -- Round the sums to 0 decimal places
        ROUND(SUM(ISNULL(pl.partslistcubic, 0) * e.est_qty), 0) as PhaseTotalCubicInches,
        ROUND(SUM(ISNULL(pl.partslistweight, 0) * e.est_qty), 0) as PhaseTotalWeight
    FROM dbo.pjjobbudexp e
    LEFT JOIN dbo.parts_list_weights_values pl ON e.partno = pl.partno
    WHERE e.entityno = @entityno 
       OR e.entityno LIKE @entityno + '-%'
    GROUP BY e.entityno
)
SELECT 
    p.entityno, 
    p.entitydesc, 
    p.proptype,
    -- Get the rounded totals
    TotalCubicInches = ISNULL(et.PhaseTotalCubicInches, 0),
    TotalWeight = ISNULL(et.PhaseTotalWeight, 0),
    -- ... rest of your columns ...
    p.startdate, 
    p.enddate, 
    p.LoadOut, 
    p.CrewPrep, 
    p.FirstShow, 
    p.LastShow,
    custno = NULLIF(p.custno, ''), 
    p.subno, 
    p.shipno,
    p.BillingCompany, 
    p.agency, 
    p.industry, 
    p.internal_org,
    p.engactivecd, 
    p.finactivecd, 
    p.plactivecd, 
    p.sfactivecd,
    p.respempno, 
    p.opsmgr, 
    p.engrEmpno, 
    p.acctExecEmpno, 
    p.RFPLEmpno,
    p.propduedate, 
    p.bidmarkup, 
    p.probability,
    currency = ISNULL(p.currency, 'USD'),
    ExchangeRateDate = ISNULL(p.ExchangeRateDate, dbo.Today()),
    ReferralProgramID,
    p.TruckingConfirmed, 
    p.TruckingVendNo,
    p.PollstarArtistID, 
    p.CRMLeadURL, 
    p.GUID, 
    p.PriceLevelValue, 
    p.TaxTypeKey,
    p.oe_orderno, 
    p.leadTime, 
    p.matrixcd, 
    p.tax_code,
    p.crewOpsEmpno, 
    p.secondaryOpsEmpno, 
    p.secondaryCrewOpsEmpno
FROM glentities p
LEFT JOIN EquipmentTotals et ON et.entityno = p.entityno
WHERE p.entityno = @entityno 
   OR p.entityno LIKE @entityno + '-%';