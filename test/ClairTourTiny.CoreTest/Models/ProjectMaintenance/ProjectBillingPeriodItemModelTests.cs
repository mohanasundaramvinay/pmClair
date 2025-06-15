using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using System;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectBillingPeriodItemModelTests
    {
        [Test]
        public void DefaultValues_ShouldBeInitializedCorrectly()
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
        public void SetAndGetProperties_ShouldWorkCorrectly()
        {
            var model = new ProjectBillingPeriodItemModel();

            model.BidEntityNo = "BID123";
            model.PeriodNo = 1;
            model.ItemNo = 2;
            model.ItemDescription = "Description";
            model.StartDate = new DateTime(2023, 1, 1);
            model.EndDate = new DateTime(2023, 12, 31);
            model.ActualDailyRate = 100.0;
            model.IsActive = true;
            model.BillingDays = 10.0;
            model.CrewSeqNo = 5;
            model.ExpenseEntityNo = "EXP123";
            model.Category = "Category1";
            model.ExpenseSeqNo = 10;
            model.CrewEntityNo = "CREW123";
            model.EquipmentEntityNo = "EQUIP123";

            Assert.AreEqual("BID123", model.BidEntityNo);
            Assert.AreEqual(1, model.PeriodNo);
            Assert.AreEqual(2, model.ItemNo);
            Assert.AreEqual("Description", model.ItemDescription);
            Assert.AreEqual(new DateTime(2023, 1, 1), model.StartDate);
            Assert.AreEqual(new DateTime(2023, 12, 31), model.EndDate);
            Assert.AreEqual(100.0, model.ActualDailyRate);
            Assert.IsTrue(model.IsActive);
            Assert.AreEqual(10.0, model.BillingDays);
            Assert.AreEqual(5, model.CrewSeqNo);
            Assert.AreEqual("EXP123", model.ExpenseEntityNo);
            Assert.AreEqual("Category1", model.Category);
            Assert.AreEqual(10, model.ExpenseSeqNo);
            Assert.AreEqual("CREW123", model.CrewEntityNo);
            Assert.AreEqual("EQUIP123", model.EquipmentEntityNo);
        }
    }
}