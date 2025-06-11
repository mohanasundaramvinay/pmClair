using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class SubtotalSummaryTests
    {
        [Test]
        public void CalculateVariance_ProjectBenchmarkIsZero_SetsVarianceToZeroAndNeutral()
        {
            var summary = new SubtotalSummary
            {
                ProjectTotal = 1000,
                ProjectBenchmark = 0
            };
            summary.CalculateVariance();
            Assert.AreEqual(0, summary.VariancePercentage);
            Assert.AreEqual(0, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Neutral, summary.VarianceIndicator);
        }
        [Test]
        public void CalculateVariance_ProjectTotalGreaterThanBenchmark_SetsPositiveVariance()
        {
            var summary = new SubtotalSummary
            {
                ProjectTotal = 1200,
                ProjectBenchmark = 1000
            };
            summary.CalculateVariance();
            Assert.AreEqual(20, summary.VariancePercentage);
            Assert.AreEqual(200, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Positive, summary.VarianceIndicator);
        }
        [Test]
        public void CalculateVariance_ProjectTotalLessThanBenchmark_SetsNegativeVariance()
        {
            var summary = new SubtotalSummary
            {
                ProjectTotal = 800,
                ProjectBenchmark = 1000
            };
            summary.CalculateVariance();
            Assert.AreEqual(-20, summary.VariancePercentage);
            Assert.AreEqual(-200, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Negative, summary.VarianceIndicator);
        }
        [Test]
        public void CalculateVariance_ProjectTotalEqualsBenchmark_SetsNeutralVariance()
        {
            var summary = new SubtotalSummary
            {
                ProjectTotal = 1000,
                ProjectBenchmark = 1000
            };
            summary.CalculateVariance();
            Assert.AreEqual(0, summary.VariancePercentage);
            Assert.AreEqual(0, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Neutral, summary.VarianceIndicator);
        }
    }
}