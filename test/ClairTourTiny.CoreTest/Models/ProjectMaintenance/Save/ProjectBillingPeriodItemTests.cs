using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class ProjectBillingPeriodItemTests
    {
        [Test]
        public void Test_UpdateTime_Property()
        {
            var item = new ProjectBillingPeriodItem();
            var now = DateTime.Now;
            item.UpdateTime = now;
            Assert.AreEqual(now, item.UpdateTime);
        }
        [Test]
        public void Test_IsInsert_Property()
        {
            var item = new ProjectBillingPeriodItem();
            item.IsInsert = true;
            Assert.IsTrue(item.IsInsert);
        }
        [Test]
        public void Test_IsUpdate_Property()
        {
            var item = new ProjectBillingPeriodItem();
            item.IsUpdate = true;
            Assert.IsTrue(item.IsUpdate);
        }
        [Test]
        public void Test_IsDelete_Property()
        {
            var item = new ProjectBillingPeriodItem();
            item.IsDelete = true;
            Assert.IsTrue(item.IsDelete);
        }
        [Test]
        public void Test_BidEntityno_Property()
        {
            var item = new ProjectBillingPeriodItem();
            var bidEntityno = "BID123";
            item.BidEntityno = bidEntityno;
            Assert.AreEqual(bidEntityno, item.BidEntityno);
        }
        [Test]
        public void Test_Periodno_Property()
        {
            var item = new ProjectBillingPeriodItem();
            short periodno = 5;
            item.Periodno = periodno;
            Assert.AreEqual(periodno, item.Periodno);
        }
        [Test]
        public void Test_Itemno_Property()
        {
            var item = new ProjectBillingPeriodItem();
            short itemno = 10;
            item.Itemno = itemno;
            Assert.AreEqual(itemno, item.Itemno);
        }
        [Test]
        public void Test_StartDate_Property()
        {
            var item = new ProjectBillingPeriodItem();
            DateTime? startDate = DateTime.Now;
            item.StartDate = startDate;
            Assert.AreEqual(startDate, item.StartDate);
        }
        [Test]
        public void Test_EndDate_Property()
        {
            var item = new ProjectBillingPeriodItem();
            DateTime? endDate = DateTime.Now;
            item.EndDate = endDate;
            Assert.AreEqual(endDate, item.EndDate);
        }
        [Test]
        public void Test_AdjustedWeekly_Property()
        {
            var item = new ProjectBillingPeriodItem();
            decimal? adjustedWeekly = 100.50m;
            item.AdjustedWeekly = adjustedWeekly;
            Assert.AreEqual(adjustedWeekly, item.AdjustedWeekly);
        }
        [Test]
        public void Test_IsActive_Property()
        {
            var item = new ProjectBillingPeriodItem();
            int isActive = 1;
            item.IsActive = isActive;
            Assert.AreEqual(isActive, item.IsActive);
        }
        [Test]
        public void Test_BillingDays_Property()
        {
            var item = new ProjectBillingPeriodItem();
            double? billingDays = 5.5;
            item.BillingDays = billingDays;
            Assert.AreEqual(billingDays, item.BillingDays);
        }
        [Test]
        public void Test_ActualDailyRate_Property()
        {
            var item = new ProjectBillingPeriodItem();
            double actualDailyRate = 200.75;
            item.ActualDailyRate = actualDailyRate;
            Assert.AreEqual(actualDailyRate, item.ActualDailyRate);
        }
    }
}