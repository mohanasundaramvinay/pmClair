using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ItemSummaryTests
    {
        [Test]
        public void CalculateVariance_ProjectBenchmarkIsZero_SetsVarianceToZeroAndNeutral()
        {
            var itemSummary = new ItemSummary { ProjectBenchmark = 0, ProjectTotal = 100 };
            itemSummary.CalculateVariance();
            Assert.AreEqual(0, itemSummary.VariancePercentage);
            Assert.AreEqual(0, itemSummary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Neutral, itemSummary.VarianceIndicator);
        }

        [Test]
        public void CalculateVariance_ProjectTotalGreaterThanBenchmark_SetsPositiveVariance()
        {
            var itemSummary = new ItemSummary { ProjectBenchmark = 100, ProjectTotal = 150 };
            itemSummary.CalculateVariance();
            Assert.AreEqual(50, itemSummary.VarianceDollars);
            Assert.AreEqual(50, itemSummary.VariancePercentage);
            Assert.AreEqual(VarianceIndicator.Positive, itemSummary.VarianceIndicator);
        }

        [Test]
        public void CalculateVariance_ProjectTotalLessThanBenchmark_SetsNegativeVariance()
        {
            var itemSummary = new ItemSummary { ProjectBenchmark = 150, ProjectTotal = 100 };
            itemSummary.CalculateVariance();
            Assert.AreEqual(-50, itemSummary.VarianceDollars);
            Assert.AreEqual(-33.33, itemSummary.VariancePercentage);
            Assert.AreEqual(VarianceIndicator.Negative, itemSummary.VarianceIndicator);
        }

        [Test]
        public void CalculateVariance_ProjectTotalEqualsBenchmark_SetsNeutralVariance()
        {
            var itemSummary = new ItemSummary { ProjectBenchmark = 100, ProjectTotal = 100 };
            itemSummary.CalculateVariance();
            Assert.AreEqual(0, itemSummary.VarianceDollars);
            Assert.AreEqual(0, itemSummary.VariancePercentage);
            Assert.AreEqual(VarianceIndicator.Neutral, itemSummary.VarianceIndicator);
        }
    }
}