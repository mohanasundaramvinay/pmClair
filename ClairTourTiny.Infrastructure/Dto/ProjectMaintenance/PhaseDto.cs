﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ClairTourTiny.Infrastructure.Dto.ProjectMaintenance
{
    public class PhaseDto
    {
        public string? EntityNo { get; set; }
        public string? EntityDesc { get; set; }
        public string? PropType { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LoadOut { get; set; }
        public DateTime? CrewPrep { get; set; }
        public DateTime? FirstShow { get; set; }
        public DateTime? LastShow { get; set; }

        public string? CustNo { get; set; }
        public string? SubNo { get; set; }
        public string? ShipNo { get; set; }

        public string? BillingCompany { get; set; }
        public string? Agency { get; set; }
        public string? Industry { get; set; }

        [Column("internal_org")]
        public string? InternalOrg { get; set; }
                     
        public string? EngActiveCd { get; set; }
        public string? FinActiveCd { get; set; }
        public string? PlActiveCd { get; set; }
        public string? SfActiveCd { get; set; }
                     
        public string? RespEmpNo { get; set; }
        public string? OpsMgr { get; set; }
        public string? EngrEmpNo { get; set; }
        public string? AcctExecEmpNo { get; set; }
        public string? RFPLEmpNo { get; set; }

        public DateTime? PropDueDate { get; set; }
        public double? BidMarkup { get; set; }
        public int? Probability { get; set; }

        public string? Currency { get; set; }
        public DateTime? ExchangeRateDate { get; set; }

        public int? ReferralProgramID { get; set; }

        public bool? TruckingConfirmed { get; set; }
        public string? TruckingVendNo { get; set; }

        public int? PollstarArtistID { get; set; }
        public string? CRMLeadURL { get; set; }
        public Guid? GUID { get; set; }

        public decimal? PriceLevelValue { get; set; }
        public int? TaxTypeKey { get; set; }

        [Column("oe_orderno")]
        public string? OeOrderNo { get; set; }
        public int? LeadTime { get; set; }

        public string? MatrixCd { get; set; }

        [Column("tax_code")]
        public string? TaxCode { get; set; }
                     
        public string? CrewOpsEmpNo { get; set; }
        public string? SecondaryOpsEmpNo { get; set; }
        public string? SecondaryCrewOpsEmpNo { get; set; }

        public double TotalCubicInches { get; set; } = 0;
        public double TotalWeight { get; set; } = 0;
    }

}
