namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class ProjectBidExpenseModel
    {
        public string EntityNo { get; set; } = string.Empty;
        public int SeqNo { get; set; }
        public string ExpenseCode { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public double ItemCost { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Cost { get; set; } = 0;
    }
}
