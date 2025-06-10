namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class BidSummaryResponse
    {
        public EquipmentSummaryResponse Equipment { get; set; } = new();
        public CrewSummaryResponse Crew { get; set; } = new();
        public ExpenseSummaryResponse Expenses { get; set; } = new();
        public List<ProjectBillingPeriodModel> BillingPeriods { get; set; } = new();
        public List<ProjectBillingPeriodItemModel> BillingPeriodItems { get; set; } = new();
        public double WeeklyTotal { get; set; }
        public double GrandTotal { get; set; }
        public double BenchmarkTotal { get; set; }
        public double QuoteMinGrandTotal { get; set; }
        public double QuoteEquipmentValue { get; set; }
        public double OverrideMarkupPercentage { get; set; }
        public double ProposedWeekly { get; set; }
        public double ProposedTotal { get; set; }
        public bool RevenueOnSalesForecast { get; set; }
        public double DefaultMarkupPercentage { get; set; }
    }
}
