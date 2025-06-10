namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class EquipmentSummaryResponse
    {
        public List<ItemSummary> Items { get; set; } = new();
        public SubtotalSummary Subtotal { get; set; } = new();
    }
}