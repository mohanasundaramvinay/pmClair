using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class SubtotalSummaryTests
    {
        [Test]
        public void CalculateVariance_ProjectBenchmarkIsZero_SetsVarianceToZeroAndNeutral()
        {
            var summary = new SubtotalSummary { ProjectBenchmark = 0, ProjectTotal = 1000 };
            summary.CalculateVariance();
            Assert.AreEqual(0, summary.VariancePercentage);
            Assert.AreEqual(0, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Neutral, summary.VarianceIndicator);
        }

        [Test]
        public void CalculateVariance_ProjectTotalGreaterThanBenchmark_SetsPositiveVariance()
        {
            var summary = new SubtotalSummary { ProjectBenchmark = 1000, ProjectTotal = 1100 };
            summary.CalculateVariance();
            Assert.AreEqual(10, summary.VariancePercentage);
            Assert.AreEqual(100, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Positive, summary.VarianceIndicator);
        }

        [Test]
        public void CalculateVariance_ProjectTotalLessThanBenchmark_SetsNegativeVariance()
        {
            var summary = new SubtotalSummary { ProjectBenchmark = 1000, ProjectTotal = 900 };
            summary.CalculateVariance();
            Assert.AreEqual(-10, summary.VariancePercentage);
            Assert.AreEqual(-100, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Negative, summary.VarianceIndicator);
        }

        [Test]
        public void CalculateVariance_ProjectTotalEqualsBenchmark_SetsNeutralVariance()
        {
            var summary = new SubtotalSummary { ProjectBenchmark = 1000, ProjectTotal = 1000 };
            summary.CalculateVariance();
            Assert.AreEqual(0, summary.VariancePercentage);
            Assert.AreEqual(0, summary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Neutral, summary.VarianceIndicator);
        }
    }
}