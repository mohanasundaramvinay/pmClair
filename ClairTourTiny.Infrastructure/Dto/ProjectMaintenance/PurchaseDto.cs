using System.ComponentModel.DataAnnotations.Schema;

namespace ClairTourTiny.Infrastructure.Dto.ProjectMaintenance
{
    public class PurchaseDto
    {
        public int IdPurchaseOrder { get; set; }
        public int PONumber { get; set; }
        public string? PODescription { get; set; }
        public string Company { get; set; } = string.Empty;
        public string? EntityNo { get; set; }
        public string RequestedBy { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string? Purchaser { get; set; }
        public DateTime? OrderedDate { get; set; }
        public string? VendNo { get; set; }

        [Column("vendsite_no")]
        public string? VendSiteNo { get; set; }

        [Column("vendor_name")]
        public string? VendorName { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string? CanceledBy { get; set; }
        public DateTime? CanceledDate { get; set; }
    }
}
