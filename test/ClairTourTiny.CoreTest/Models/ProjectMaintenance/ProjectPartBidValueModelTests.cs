using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ProjectPartBidValueModelTests
    {
        [Test]
        public void PartNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectPartBidValueModel();
            model.PartNo = "12345";
            Assert.AreEqual("12345", model.PartNo);
        }

        [Test]
        public void Currency_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectPartBidValueModel();
            model.Currency = "USD";
            Assert.AreEqual("USD", model.Currency);
        }

        [Test]
        public void ValueType_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectPartBidValueModel();
            model.ValueType = "Fixed";
            Assert.AreEqual("Fixed", model.ValueType);
        }

        [Test]
        public void BidValue_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectPartBidValueModel();
            model.BidValue = 1000.50;
            Assert.AreEqual(1000.50, model.BidValue);
        }
    }
}