using NUnit.Framework;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class VarianceIndicatorTests
    {
        [Test]
        public void VarianceIndicator_ShouldHaveCorrectValues()
        {
            Assert.AreEqual(0, (int)VarianceIndicator.Neutral, "Neutral should be 0");
            Assert.AreEqual(1, (int)VarianceIndicator.Positive, "Positive should be 1");
            Assert.AreEqual(2, (int)VarianceIndicator.Negative, "Negative should be 2");
        }

        [Test]
        public void VarianceIndicator_ShouldBeAssignable()
        {
            VarianceIndicator indicator = VarianceIndicator.Neutral;
            Assert.AreEqual(VarianceIndicator.Neutral, indicator);

            indicator = VarianceIndicator.Positive;
            Assert.AreEqual(VarianceIndicator.Positive, indicator);

            indicator = VarianceIndicator.Negative;
            Assert.AreEqual(VarianceIndicator.Negative, indicator);
        }
    }
}