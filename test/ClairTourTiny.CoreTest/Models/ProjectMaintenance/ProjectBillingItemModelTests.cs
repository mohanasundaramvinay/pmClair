using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ProjectBillingItemModelTests
    {
        [Test]
        public void TestBidEntityNoProperty()
        {
            var model = new ProjectBillingItemModel();
            var expected = "12345";
            model.BidEntityNo = expected;
            Assert.AreEqual(expected, model.BidEntityNo);
        }

        [Test]
        public void TestItemNoProperty()
        {
            var model = new ProjectBillingItemModel();
            short expected = 10;
            model.ItemNo = expected;
            Assert.AreEqual(expected, model.ItemNo);
        }

        [Test]
        public void TestEquipmentEntityNoProperty()
        {
            var model = new ProjectBillingItemModel();
            var expected = "EQ123";
            model.EquipmentEntityNo = expected;
            Assert.AreEqual(expected, model.EquipmentEntityNo);
        }

        [Test]
        public void TestExpenseEntityNoProperty()
        {
            var model = new ProjectBillingItemModel();
            var expected = "EXP456";
            model.ExpenseEntityNo = expected;
            Assert.AreEqual(expected, model.ExpenseEntityNo);
        }

        [Test]
        public void TestExpenseSeqNoProperty()
        {
            var model = new ProjectBillingItemModel();
            int? expected = 100;
            model.ExpenseSeqNo = expected;
            Assert.AreEqual(expected, model.ExpenseSeqNo);
        }

        [Test]
        public void TestCrewEntityNoProperty()
        {
            var model = new ProjectBillingItemModel();
            var expected = "CRW789";
            model.CrewEntityNo = expected;
            Assert.AreEqual(expected, model.CrewEntityNo);
        }

        [Test]
        public void TestCrewEmpLineNoProperty()
        {
            var model = new ProjectBillingItemModel();
            int? expected = 5;
            model.CrewEmpLineNo = expected;
            Assert.AreEqual(expected, model.CrewEmpLineNo);
        }

        [Test]
        public void TestNominalDailyRateProperty()
        {
            var model = new ProjectBillingItemModel();
            double expected = 250.75;
            model.NominalDailyRate = expected;
            Assert.AreEqual(expected, model.NominalDailyRate);
        }
    }
}