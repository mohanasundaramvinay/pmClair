using System.ComponentModel.DataAnnotations;

namespace ClairTourTiny.Infrastructure.Dto.DTOs
{
    public class PartSearchRequestDto
    {
        public string SearchText { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public bool HideUnusedParts { get; set; }
        public bool OnlyMyWarehouses { get; set; }
        public bool MyPartsOnly { get; set; }
        public bool SearchForBarcode { get; set; }
    }

    public class PartSearchResultDto
    {
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public string Commodity { get; set; }
        public string PartGroup { get; set; }
        public int PartSequence { get; set; }
        public double PartsListWeight { get; set; }
        public double? PartsListCubic { get; set; }
        public double PartsListValue { get; set; }
        public string Sku { get; set; }
        public bool IsUnusedPart { get; set; }
        public bool IsInMyWarehouse { get; set; }
        public bool IsMyPart { get; set; }

        // Bottleneck fields
        public decimal Bottleneck { get; set; }
        public decimal Bottleneck1d { get; set; }
        public decimal Bottleneck1w { get; set; }
        public decimal WarehouseQty { get; set; }
        public decimal MaxCumulativeQty { get; set; }
        public decimal DayOfDemand { get; set; }
        public decimal WeekOfDemand { get; set; }

        public string Currency { get; set; } = string.Empty;

        public string ValueType { get; set; } = string.Empty;

        public decimal BidValue { get; set; }
    }

    public class PartCategoryDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class PartSubCategoryDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Commodity { get; set; }
    }

    /// <summary>
    /// DTO for bottleneck calculation results
    /// </summary>
    public class PartBottleneckDto
    {
        /// <summary>
        /// Part number
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Original bottleneck calculation (warehouse qty - cumulative qty)
        /// </summary>
        public decimal Bottleneck { get; set; }

        /// <summary>
        /// Day of demand bottleneck (warehouse qty - day of demand)
        /// </summary>
        public decimal Bottleneck1d { get; set; }

        /// <summary>
        /// Week of demand bottleneck (warehouse qty - week of demand)
        /// </summary>
        public decimal Bottleneck1w { get; set; }

        /// <summary>
        /// Warehouse quantity available
        /// </summary>
        public decimal WarehouseQty { get; set; }

        /// <summary>
        /// Maximum cumulative quantity from transactions
        /// </summary>
        public decimal MaxCumulativeQty { get; set; }

        /// <summary>
        /// Day of demand quantity
        /// </summary>
        public decimal DayOfDemand { get; set; }

        /// <summary>
        /// Week of demand quantity
        /// </summary>
        public decimal WeekOfDemand { get; set; }
    }

    /// <summary>
    /// Request DTO for bottleneck calculation
    /// </summary>
    public class PartBottleneckRequestDto
    {
        /// <summary>
        /// List of part numbers to calculate bottlenecks for
        /// </summary>
        public List<string> PartNumbers { get; set; } = new List<string>();

        /// <summary>
        /// From date for filtering transactions (optional)
        /// </summary>
        public DateTime? FromDate { get; set; }
    }
} 