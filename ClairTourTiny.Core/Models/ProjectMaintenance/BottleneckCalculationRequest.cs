using System.ComponentModel.DataAnnotations;

namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    /// <summary>
    /// Request model for bottleneck calculation
    /// </summary>
    public class BottleneckCalculationRequest
    {
        /// <summary>
        /// List of equipment items to calculate bottlenecks for
        /// </summary>
        [Required]
        public List<EquipmentBottleneckItem> EquipmentItems { get; set; } = new();

        /// <summary>
        /// Project number for context
        /// </summary>
        [Required]
        public string ProjectNumber { get; set; } = string.Empty;
    }

    /// <summary>
    /// Individual equipment item for bottleneck calculation
    /// </summary>
    public class EquipmentBottleneckItem
    {
        /// <summary>
        /// Equipment entity number
        /// </summary>
        [Required]
        public string EntityNo { get; set; } = string.Empty;

        /// <summary>
        /// Part number
        /// </summary>
        [Required]
        public string PartNo { get; set; } = string.Empty;

        /// <summary>
        /// Warehouse/agency
        /// </summary>
        [Required]
        public string Warehouse { get; set; } = string.Empty;

        /// <summary>
        /// Start date for the equipment
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date for the equipment
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Quantity needed
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Quantity already checked out
        /// </summary>
        public int CheckedOut { get; set; }
    }

    /// <summary>
    /// DTO for base inventory query results
    /// </summary>
    public class BaseInventoryDto
    {
        public string Warehouse { get; set; } = string.Empty;
        public string Partno { get; set; } = string.Empty;
        public int Qty { get; set; }
    }

    /// <summary>
    /// DTO for external demands query results
    /// </summary>
    public class ExternalDemandDto
    {
        public string Warehouse { get; set; } = string.Empty;
        public string Partno { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public int Qty { get; set; }
    }
} 