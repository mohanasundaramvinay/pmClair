using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ProjectBillingPeriodItemModelTests
    {
        [Test]
        public void DefaultValues_ShouldBeSetCorrectly()
        {
            var model = new ProjectBillingPeriodItemModel();

            Assert.AreEqual(string.Empty, model.BidEntityNo);
            Assert.AreEqual(0, model.PeriodNo);
            Assert.AreEqual(0, model.ItemNo);
            Assert.IsNull(model.ItemDescription);
            Assert.IsNull(model.StartDate);
            Assert.IsNull(model.EndDate);
            Assert.AreEqual(0.0, model.ActualDailyRate);
            Assert.IsFalse(model.IsActive);
            Assert.IsNull(model.BillingDays);
            Assert.IsNull(model.Days);
            Assert.IsNull(model.ActiveActualDailyRate);
            Assert.IsNull(model.ActiveActualDays);
            Assert.IsNull(model.ActiveActualValue);
            Assert.IsNull(model.ActivePeriodDays);
            Assert.IsNull(model.Rate);
            Assert.IsNull(model.PeriodTotal);
            Assert.IsNull(model.BenchmarkDollars);
            Assert.AreEqual(0, model.IsFixedExpense);
            Assert.IsNull(model.BenchmarkTotal);
            Assert.IsNull(model.MarkupPct);
            Assert.IsNull(model.BenchmarkVariancePct);
            Assert.IsNull(model.BenchmarkVarianceDollars);
            Assert.IsNull(model.AdjustedWeekly);
            Assert.IsNull(model.AdjustedDaily);
            Assert.IsNull(model.CrewSeqNo);
            Assert.IsNull(model.ExpenseEntityNo);
            Assert.IsNull(model.Category);
            Assert.IsNull(model.ExpenseSeqNo);
            Assert.IsNull(model.CrewEntityNo);
            Assert.IsNull(model.EquipmentEntityNo);
        }

        [Test]
        public void SetValues_ShouldBeRetrievable()
        {
            var model = new ProjectBillingPeriodItemModel
            {
                BidEntityNo = "B123",
                PeriodNo = 1,
                ItemNo = 2,
                ItemDescription = "Test Item",
                StartDate = new DateTime(2023, 1, 1),
                EndDate = new DateTime(2023, 12, 31),
                ActualDailyRate = 100.0,
                IsActive = true,
                BillingDays = 10.0,
                CrewSeqNo = 5,
                ExpenseEntityNo = "E123",
                Category = "Test Category",
                ExpenseSeqNo = 10,
                CrewEntityNo = "C123",
                EquipmentEntityNo = "EQ123"
            };

            Assert.AreEqual("B123", model.BidEntityNo);
            Assert.AreEqual(1, model.PeriodNo);
            Assert.AreEqual(2, model.ItemNo);
            Assert.AreEqual("Test Item", model.ItemDescription);
            Assert.AreEqual(new DateTime(2023, 1, 1), model.StartDate);
            Assert.AreEqual(new DateTime(2023, 12, 31), model.EndDate);
            Assert.AreEqual(100.0, model.ActualDailyRate);
            Assert.IsTrue(model.IsActive);
            Assert.AreEqual(10.0, model.BillingDays);
            Assert.AreEqual(5, model.CrewSeqNo);
            Assert.AreEqual("E123", model.ExpenseEntityNo);
            Assert.AreEqual("Test Category", model.Category);
            Assert.AreEqual(10, model.ExpenseSeqNo);
            Assert.AreEqual("C123", model.CrewEntityNo);
            Assert.AreEqual("EQ123", model.EquipmentEntityNo);
        }
    }
}