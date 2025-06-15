using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ProjectPartBidValueModelTests
    {
        [Test]
        public void DefaultValues_ShouldBeEmptyOrZero()
        {
            var model = new ProjectPartBidValueModel();
            Assert.AreEqual(string.Empty, model.PartNo);
            Assert.AreEqual(string.Empty, model.Currency);
            Assert.AreEqual(string.Empty, model.ValueType);
            Assert.AreEqual(0.0, model.BidValue);
        }
        [Test]
        public void SetAndGetProperties_ShouldReturnCorrectValues()
        {
            var model = new ProjectPartBidValueModel();
            model.PartNo = "12345";
            model.Currency = "USD";
            model.ValueType = "Fixed";
            model.BidValue = 1000.50;
            Assert.AreEqual("12345", model.PartNo);
            Assert.AreEqual("USD", model.Currency);
            Assert.AreEqual("Fixed", model.ValueType);
            Assert.AreEqual(1000.50, model.BidValue);
        }
    }
}