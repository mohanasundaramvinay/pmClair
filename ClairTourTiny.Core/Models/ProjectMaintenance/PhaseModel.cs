using System.Text.Json.Serialization;

namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class PhaseModel
    {
        public string EntityNo { get; set; } = string.Empty;
        public string EntityDesc { get; set; } = string.Empty;
        public string BillingCompany { get; set; } = string.Empty;

        [JsonPropertyName("ProposalType")]
        public string PropType { get; set; } = string.Empty;

        [JsonPropertyName("AccountExecutive")]
        public string RespEmpNo { get; set; } = string.Empty;

        [JsonPropertyName("AccountExecutiveSecondary")]
        public string AcctExecEmpNo { get; set; } = string.Empty;

        [JsonPropertyName("OperationsManager")]
        public string OpsMgr { get; set; } = string.Empty;

        [JsonPropertyName("SecondaryOperations")]
        public string SecondaryOpsEmpNo { get; set; } = string.Empty;
        
        [JsonPropertyName("CrewOps")]
        public string CrewOpsEmpNo { get; set; } = string.Empty;

        [JsonPropertyName("ProjectEngineer")]
        public string? EngrEmpNo { get; set; }

        [JsonPropertyName("RFPLConsultant")]
        public string? RFPLEmpNo { get; set; }

        [JsonPropertyName("FromWarehouse")]
        public string? Agency { get; set; }

        [JsonPropertyName("ToWarehouse")]
        public string? Industry { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonPropertyName("ActiveStatus")]
        public string? EngActiveCd { get; set; }
        public int? Probability { get; set; }

        [JsonPropertyName("ProjectCalendarStatus")]
        public string? FinActiveCd { get; set; }

        [JsonPropertyName("ProjectListStatus")]
        public string? PlActiveCd { get; set; }

        [JsonPropertyName("SalesForecast")]
        public string? SfActiveCd { get; set; }

        [JsonPropertyName("TruckingConfirmed")]
        public bool? TruckingConfirmed { get; set; }

        [JsonPropertyName("TruckingCompany")]
        public string? TruckingVendNo { get; set; }

        [JsonPropertyName("Referral")]
        public int? ReferralProgramID { get; set; }

        [JsonPropertyName("TaxType")]
        public string? TaxCode { get; set; }
        public int? PollstarArtistID { get; set; }
        
        [JsonPropertyName("CRMLead")]
        public string? CRMLeadURL { get; set; }

        [JsonPropertyName("Customer")]
        public string? CustNo { get; set; }
        public string? Currency { get; set; }
        public DateTime? ExchangeRateDate { get; set; }
        public double? PriceLevelValue { get; set; }

        [JsonPropertyName("MatrixCode")]
        public string? MatrixCd { get; set; }

        [JsonPropertyName("BillingAddress")]
        public string? SubNo { get; set; }
        [JsonPropertyName("ShippingAddress")]
        public string? ShipNo { get; set; }



        public DateTime? LoadOut { get; set; }
        public DateTime? CrewPrep { get; set; }
        public DateTime? FirstShow { get; set; }
        public DateTime? LastShow { get; set; }
        public string? InternalOrg { get; set; }
        public DateTime? PropDueDate { get; set; }
        public double? BidMarkup { get; set; }
        public Guid? GUID { get; set; }
        public int? TaxTypeKey { get; set; }
        public string? OeOrderNo { get; set; }
        public int? LeadTime { get; set; }

        [JsonPropertyName("TotalWeight")]
        public double TotalWeight { get; set; }

        [JsonPropertyName("TotalVolume")]
        public double TotalCubicInches { get; set; } = 0;
        [JsonPropertyName("TotalEquipmentCost")]
        public double TotalEquipmentCost { get; set; } = 0;
        
        [JsonPropertyName("IsRackConfigured")]
        public bool? IsRackConfigured { get; set; }

    }
}
