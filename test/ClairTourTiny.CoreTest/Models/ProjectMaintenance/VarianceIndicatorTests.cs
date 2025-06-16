using NUnit.Framework;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class VarianceIndicatorTests
    {
        [Test]
        public void VarianceIndicator_ShouldHaveNeutralValue()
        {
            Assert.AreEqual(0, (int)VarianceIndicator.Neutral);
        }

        [Test]
        public void VarianceIndicator_ShouldHavePositiveValue()
        {
            Assert.AreEqual(1, (int)VarianceIndicator.Positive);
        }

        [Test]
        public void VarianceIndicator_ShouldHaveNegativeValue()
        {
            Assert.AreEqual(2, (int)VarianceIndicator.Negative);
        }
    }
}