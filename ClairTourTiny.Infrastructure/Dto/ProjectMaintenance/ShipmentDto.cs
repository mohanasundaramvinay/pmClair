public class ShipmentDto
{
    public string? ProjectLegNo { get; set; }
    public string EntityNo { get; set; } = string.Empty;
    public string? EntityDesc { get; set; }
    public DateTime ShipDate { get; set; }
    public string? Destination { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? TrackingNo { get; set; }
    public decimal? EstimatedCost { get; set; }
    public decimal? Cost { get; set; }
    public int? ShippingRequestID { get; set; }
    public string ServiceType { get; set; } = string.Empty;
}
