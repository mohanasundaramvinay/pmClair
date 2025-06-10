namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class SubtotalSummary
    {
        public double BaseWeekly { get; set; }
        public double BidValue { get; set; }
        public double WeeklyOperationalExpense { get; set; }
        public double WeeklyTotal { get; set; }
        public double ClientTotal { get; set; }
        public double OperationalTotal { get; set; }
        public double DailyRate { get; set; }
        public double ProjectTotal { get; set; }
        public double ProjectBenchmark { get; set; }
        public double VariancePercentage { get; set; }
        public double VarianceDollars { get; set; }
        public VarianceIndicator VarianceIndicator { get; set; }
        public void CalculateVariance()
        {
            if (ProjectBenchmark == 0)
            {
                VariancePercentage = 0;
                VarianceDollars = 0;
                VarianceIndicator = VarianceIndicator.Neutral;
                return;
            }

            VarianceDollars = ProjectTotal - ProjectBenchmark;
            VariancePercentage = Math.Round((ProjectTotal / ProjectBenchmark * 100) - 100, 2);

            var variance = Math.Round(ProjectTotal / ProjectBenchmark - 1, 2);
            VarianceIndicator = variance switch
            {
                < 0 => VarianceIndicator.Negative,
                > 0 => VarianceIndicator.Positive,
                _ => VarianceIndicator.Neutral
            };
        }
    }
}