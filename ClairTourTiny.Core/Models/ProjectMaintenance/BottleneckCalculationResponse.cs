namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    /// <summary>
    /// Response model for bottleneck calculation
    /// </summary>
    public class BottleneckCalculationResponse
    {
        /// <summary>
        /// List of calculated bottleneck results
        /// </summary>
        public List<BottleneckResult> Results { get; set; } = new();

        /// <summary>
        /// Calculation timestamp
        /// </summary>
        public DateTime CalculatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Total processing time in milliseconds
        /// </summary>
        public long ProcessingTimeMs { get; set; }
    }

    /// <summary>
    /// Individual bottleneck calculation result
    /// </summary>
    public class BottleneckResult
    {
        /// <summary>
        /// Equipment entity number
        /// </summary>
        public string EntityNo { get; set; } = string.Empty;

        /// <summary>
        /// Part number
        /// </summary>
        public string PartNo { get; set; } = string.Empty;

        /// <summary>
        /// Warehouse/agency
        /// </summary>
        public string Warehouse { get; set; } = string.Empty;

        /// <summary>
        /// Overall bottleneck value (availability across entire project duration)
        /// </summary>
        public int Bottleneck { get; set; }

        /// <summary>
        /// 1-day bottleneck value (availability on start date)
        /// </summary>
        public int Bottleneck1d { get; set; }

        /// <summary>
        /// 1-week bottleneck value (availability within first 7 days)
        /// </summary>
        public int Bottleneck1w { get; set; }

        /// <summary>
        /// Base inventory quantity available
        /// </summary>
        public int BaseInventory { get; set; }

        /// <summary>
        /// Maximum demand in date range
        /// </summary>
        public int MaxDemandInDateRange { get; set; }

        /// <summary>
        /// Maximum demand on start date
        /// </summary>
        public int MaxDemandOnStartDate { get; set; }

        /// <summary>
        /// Maximum demand in first week
        /// </summary>
        public int MaxDemandInFirstWeek { get; set; }

        /// <summary>
        /// Start date for the equipment
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date for the equipment
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Number of demand events processed
        /// </summary>
        public int DemandEventCount { get; set; }

        /// <summary>
        /// Calculation status
        /// </summary>
        public string Status { get; set; } = "Success";

        /// <summary>
        /// Error message if calculation failed
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
} 