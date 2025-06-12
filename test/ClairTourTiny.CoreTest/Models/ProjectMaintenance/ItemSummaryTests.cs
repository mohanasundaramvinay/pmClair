using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public enum VarianceIndicator
    {
        Neutral,
        Positive,
        Negative
    }
    
    [TestFixture]
    public class ItemSummaryTests
    {
        [Test]
        public void CalculateVariance_ProjectBenchmarkIsZero_SetsVarianceToZeroAndIndicatorToNeutral()
        {
            var itemSummary = new ItemSummary
            {
                ProjectTotal = 1000,
                ProjectBenchmark = 0
            };
            
            itemSummary.CalculateVariance();
            
            Assert.AreEqual(0, itemSummary.VariancePercentage);
            Assert.AreEqual(0, itemSummary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Neutral, itemSummary.VarianceIndicator);
        }
        
        [Test]
        public void CalculateVariance_ProjectTotalGreaterThanBenchmark_SetsPositiveVarianceAndIndicator()
        {
            var itemSummary = new ItemSummary
            {
                ProjectTotal = 1200,
                ProjectBenchmark = 1000
            };
            
            itemSummary.CalculateVariance();
            
            Assert.AreEqual(20, itemSummary.VariancePercentage);
            Assert.AreEqual(200, itemSummary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Positive, itemSummary.VarianceIndicator);
        }
        
        [Test]
        public void CalculateVariance_ProjectTotalLessThanBenchmark_SetsNegativeVarianceAndIndicator()
        {
            var itemSummary = new ItemSummary
            {
                ProjectTotal = 800,
                ProjectBenchmark = 1000
            };
            
            itemSummary.CalculateVariance();
            
            Assert.AreEqual(-20, itemSummary.VariancePercentage);
            Assert.AreEqual(-200, itemSummary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Negative, itemSummary.VarianceIndicator);
        }
        
        [Test]
        public void CalculateVariance_ProjectTotalEqualsBenchmark_SetsZeroVarianceAndNeutralIndicator()
        {
            var itemSummary = new ItemSummary
            {
                ProjectTotal = 1000,
                ProjectBenchmark = 1000
            };
            
            itemSummary.CalculateVariance();
            
            Assert.AreEqual(0, itemSummary.VariancePercentage);
            Assert.AreEqual(0, itemSummary.VarianceDollars);
            Assert.AreEqual(VarianceIndicator.Neutral, itemSummary.VarianceIndicator);
        }
    }
}