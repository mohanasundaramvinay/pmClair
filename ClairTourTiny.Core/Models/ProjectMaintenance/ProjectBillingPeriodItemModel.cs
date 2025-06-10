namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class ProjectBillingPeriodItemModel
    {
        public string BidEntityNo { get; set; } = string.Empty;
        public short PeriodNo { get; set; }
        public short ItemNo { get; set; }
        public string? ItemDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double ActualDailyRate { get; set; }
        public bool IsActive { get; set; }
        public double? BillingDays { get; set; }
        public int? Days { get; private set; }
        public double? ActiveActualDailyRate { get; private set; } 
        public double? ActiveActualDays { get; private set; }
        public double? ActiveActualValue { get; private set; } 
        public int? ActivePeriodDays { get; private set; }
        public double? Rate { get; private set; }
        public double? PeriodTotal { get; private set; }
        public double? BenchmarkDollars { get; private set; }
        public int IsFixedExpense { get; private set; }
        public double? BenchmarkTotal { get; private set; }
        public double? MarkupPct { get; private set; }
        public double? BenchmarkVariancePct { get; private set; }
        public double? BenchmarkVarianceDollars { get; private set; }
        public double? AdjustedWeekly { get; private set; } 
        public double? AdjustedDaily { get; private set; }
        public int? CrewSeqNo { get; set; }
        public string? ExpenseEntityNo { get; set; }
        public string? Category { get; set; }
        public int? ExpenseSeqNo { get; set; }
        public string? CrewEntityNo { get; set; }
        public string? EquipmentEntityNo { get; set; }
    }
}
