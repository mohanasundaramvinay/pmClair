using System;
using System.ComponentModel.DataAnnotations;

namespace ClairTourTiny.Infrastructure.Dto.DTOs
{
    public class PurchaseOrderDto
    {
        public int IdPurchaseOrder { get; set; }
        public int PONumber { get; set; }
        public string PODescription { get; set; }
        public string Currency { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }

    public class CreatePurchaseOrderRequest
    {
        [Required]
        public string EntityNo { get; set; }

        [Required]
        [StringLength(500)]
        public string PODescription { get; set; }
    }

    public class CreatePurchaseOrderResponse
    {
        public int PONumber { get; set; }
    }

    public class UpdatePurchaseOrderRequest
    {
        [Required]
        [StringLength(500)]
        public string PODescription { get; set; }
    }

    public class PurchaseOrderStatusRequest
    {
        [Required]
        public string Status { get; set; }
    }

    public class DateRangeRequest
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
} 