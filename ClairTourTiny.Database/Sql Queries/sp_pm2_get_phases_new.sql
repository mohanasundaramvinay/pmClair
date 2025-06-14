CREATE PROCEDURE [dbo].[pm2_get_phases_new]     
    @entityno VARCHAR(50)      
AS    
WITH EquipmentTotals AS (    
        SELECT     
            e.entityno,    
            ROUND(SUM(ISNULL(pl.partslistcubic, 0) * e.est_qty), 0) AS PhaseTotalCubicInches,    
            ROUND(SUM(ISNULL(pl.partslistweight, 0) * e.est_qty), 0) AS PhaseTotalWeight,  
            ROUND(SUM(ISNULL(e.est_unit_amount * e.est_qty * (e.markup + 1), 0)), 2) AS TotalEquipmentCost  
        FROM dbo.pjjobbudexp e    
        LEFT JOIN dbo.parts_list_weights_values pl ON e.partno = pl.partno    
        WHERE e.entityno = @entityno OR e.entityno LIKE @entityno + '-%'    
        GROUP BY e.entityno    
    )

    SELECT     
        p.entityno,     
        p.entitydesc,     
        p.proptype,   
        TotalCubicInches       = ISNULL(et.PhaseTotalCubicInches, 0),    
        TotalWeight            = ISNULL(et.PhaseTotalWeight, 0),    
        TotalEquipmentCost     = ISNULL(et.TotalEquipmentCost, 0),    
        p.startdate,     
        p.enddate,     
        p.LoadOut,     
        p.CrewPrep,     
        p.FirstShow,     
        p.LastShow,    
        custno                 = NULLIF(p.custno, ''),     
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
        currency              = ISNULL(p.currency, 'USD'),    
        ExchangeRateDate      = ISNULL(p.ExchangeRateDate, dbo.Today()),    
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
        p.secondaryCrewOpsEmpno,
        IsRackConfigured = CAST(
    IIF(rc.entityno IS NOT NULL OR rcpd.entityno IS NOT NULL, 1, 0) AS BIT
)
    FROM dbo.glentities p    
    LEFT JOIN EquipmentTotals et ON et.entityno = p.entityno
    LEFT JOIN dbo.RackConfigurator rc ON p.entityno = rc.entityno  
    LEFT JOIN dbo.RackConfiguratorPhaseDetails rcpd ON p.entityno = rcpd.entityno  
    WHERE p.entityno = @entityno OR p.entityno LIKE @entityno + '-%'
    GROUP BY 
        p.entityno, p.entitydesc, p.proptype, et.PhaseTotalCubicInches, et.PhaseTotalWeight, et.TotalEquipmentCost,
        p.startdate, p.enddate, p.LoadOut, p.CrewPrep, p.FirstShow, p.LastShow,
        p.custno, p.subno, p.shipno, p.BillingCompany, p.agency, p.industry, p.internal_org,
        p.engactivecd, p.finactivecd, p.plactivecd, p.sfactivecd, p.respempno, p.opsmgr,
        p.engrEmpno, p.acctExecEmpno, p.RFPLEmpno, p.propduedate, p.bidmarkup, p.probability,
        p.currency, p.ExchangeRateDate, p.ReferralProgramID, p.TruckingConfirmed, p.TruckingVendNo,
        p.PollstarArtistID, p.CRMLeadURL, p.GUID, p.PriceLevelValue, p.TaxTypeKey,
        p.oe_orderno, p.leadTime, p.matrixcd, p.tax_code,
        p.crewOpsEmpno, p.secondaryOpsEmpno, p.secondaryCrewOpsEmpno,
        rc.entityno, rcpd.entityno