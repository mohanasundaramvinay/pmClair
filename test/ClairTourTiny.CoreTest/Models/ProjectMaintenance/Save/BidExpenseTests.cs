using NUnit.Framework;
using System;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class BidExpenseTests
    {
        [Test]
        public void TestDefaultValues()
        {
            var bidExpense = new BidExpense();

            Assert.IsNotNull(bidExpense.Entityno);
            Assert.IsNotNull(bidExpense.Expcd);
            Assert.IsNotNull(bidExpense.PeriodType);
            Assert.IsNotNull(bidExpense.Category);
        }

        [Test]
        public void TestBooleanProperties()
        {
            var bidExpense = new BidExpense();

            bidExpense.IsInsert = true;
            Assert.IsTrue(bidExpense.IsInsert);

            bidExpense.IsUpdate = true;
            Assert.IsTrue(bidExpense.IsUpdate);

            bidExpense.IsDelete = true;
            Assert.IsTrue(bidExpense.IsDelete);
        }

        [Test]
        public void TestNullableNotesProperty()
        {
            var bidExpense = new BidExpense();

            bidExpense.Notes = null;
            Assert.IsNull(bidExpense.Notes);

            bidExpense.Notes = "Some notes";
            Assert.AreEqual("Some notes", bidExpense.Notes);
        }

        [Test]
        public void TestNumericProperties()
        {
            var bidExpense = new BidExpense();

            bidExpense.ItemCost = 100.50;
            Assert.AreEqual(100.50, bidExpense.ItemCost);

            bidExpense.ItemQty = 10;
            Assert.AreEqual(10, bidExpense.ItemQty);
        }

        [Test]
        public void TestDateTimeProperty()
        {
            var bidExpense = new BidExpense();

            var now = DateTime.Now;
            bidExpense.UpdateTime = now;
            Assert.AreEqual(now, bidExpense.UpdateTime);
        }
    }
}