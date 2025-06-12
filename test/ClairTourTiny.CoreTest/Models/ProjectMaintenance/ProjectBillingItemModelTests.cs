using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectBillingItemModelTests
    {
        [Test]
        public void BidEntityNo_DefaultValue_ShouldBeEmptyString()
        {
            var model = new ProjectBillingItemModel();
            Assert.AreEqual(string.Empty, model.BidEntityNo);
        }

        [Test]
        public void ItemNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectBillingItemModel();
            model.ItemNo = 5;
            Assert.AreEqual(5, model.ItemNo);
        }

        [Test]
        public void EquipmentEntityNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectBillingItemModel();
            model.EquipmentEntityNo = "EQ123";
            Assert.AreEqual("EQ123", model.EquipmentEntityNo);
        }

        [Test]
        public void ExpenseEntityNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectBillingItemModel();
            model.ExpenseEntityNo = "EXP456";
            Assert.AreEqual("EXP456", model.ExpenseEntityNo);
        }

        [Test]
        public void ExpenseSeqNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectBillingItemModel();
            model.ExpenseSeqNo = 10;
            Assert.AreEqual(10, model.ExpenseSeqNo);
        }

        [Test]
        public void CrewEntityNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectBillingItemModel();
            model.CrewEntityNo = "CR789";
            Assert.AreEqual("CR789", model.CrewEntityNo);
        }

        [Test]
        public void CrewEmpLineNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectBillingItemModel();
            model.CrewEmpLineNo = 15;
            Assert.AreEqual(15, model.CrewEmpLineNo);
        }

        [Test]
        public void NominalDailyRate_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectBillingItemModel();
            model.NominalDailyRate = 200.50;
            Assert.AreEqual(200.50, model.NominalDailyRate);
        }
    }
}