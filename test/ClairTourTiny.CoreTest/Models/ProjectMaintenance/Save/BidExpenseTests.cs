using NUnit.Framework;
using System;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class BidExpenseTests
    {
        [Test]
        public void BidExpense_Entityno_ShouldNotBeNullAfterInstantiation()
        {
            var bidExpense = new BidExpense();
            Assert.IsNotNull(bidExpense.Entityno);
        }

        [Test]
        public void BidExpense_Expcd_ShouldNotBeNullAfterInstantiation()
        {
            var bidExpense = new BidExpense();
            Assert.IsNotNull(bidExpense.Expcd);
        }

        [Test]
        public void BidExpense_PeriodType_ShouldNotBeNullAfterInstantiation()
        {
            var bidExpense = new BidExpense();
            Assert.IsNotNull(bidExpense.PeriodType);
        }

        [Test]
        public void BidExpense_Category_ShouldNotBeNullAfterInstantiation()
        {
            var bidExpense = new BidExpense();
            Assert.IsNotNull(bidExpense.Category);
        }

        [Test]
        public void BidExpense_Notes_CanBeNull()
        {
            var bidExpense = new BidExpense();
            bidExpense.Notes = null;
            Assert.IsNull(bidExpense.Notes);
        }

        [Test]
        public void BidExpense_Notes_CanBeSetToNonNullValue()
        {
            var bidExpense = new BidExpense();
            bidExpense.Notes = "Some notes";
            Assert.AreEqual("Some notes", bidExpense.Notes);
        }

        [Test]
        public void BidExpense_BooleanProperties_CanBeSet()
        {
            var bidExpense = new BidExpense();
            bidExpense.IsInsert = true;
            bidExpense.IsUpdate = true;
            bidExpense.IsDelete = true;
            Assert.IsTrue(bidExpense.IsInsert);
            Assert.IsTrue(bidExpense.IsUpdate);
            Assert.IsTrue(bidExpense.IsDelete);
        }

        [Test]
        public void BidExpense_NumericProperties_CanBeSet()
        {
            var bidExpense = new BidExpense();
            bidExpense.ItemCost = 100.50;
            bidExpense.ItemQty = 10;
            Assert.AreEqual(100.50, bidExpense.ItemCost);
            Assert.AreEqual(10, bidExpense.ItemQty);
        }

        [Test]
        public void BidExpense_UpdateTime_CanBeSet()
        {
            var bidExpense = new BidExpense();
            var now = DateTime.Now;
            bidExpense.UpdateTime = now;
            Assert.AreEqual(now, bidExpense.UpdateTime);
        }
    }
}