namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class ExpenseSummaryResponse
    {
        public SubtotalSummary WeeklyExpensesSubtotal { get; set; } = new();
        public SubtotalSummary SingleExpensesSubtotal { get; set; } = new();
        public List<ItemSummary>  WeeklyExpenses { get; set; } = new();
        public List<ItemSummary> SingleExpenses { get; set; } = new();
    }
}