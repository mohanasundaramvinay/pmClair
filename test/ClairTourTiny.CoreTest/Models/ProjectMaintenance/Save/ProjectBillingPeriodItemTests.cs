using NUnit.Framework;
using System;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class ProjectBillingPeriodItemTests
    {
        private ProjectBillingPeriodItem _projectBillingPeriodItem;
        
        [SetUp]
        public void Setup()
        {
            _projectBillingPeriodItem = new ProjectBillingPeriodItem();
        }
        
        [Test]
        public void UpdateTime_ShouldBeSetAndRetrievedCorrectly()
        {
            var dateTime = DateTime.Now;
            _projectBillingPeriodItem.UpdateTime = dateTime;
            Assert.AreEqual(dateTime, _projectBillingPeriodItem.UpdateTime);
        }
        
        [Test]
        public void IsInsert_ShouldBeSetAndRetrievedCorrectly()
        {
            _projectBillingPeriodItem.IsInsert = true;
            Assert.IsTrue(_projectBillingPeriodItem.IsInsert);
        }
        
        [Test]
        public void IsUpdate_ShouldBeSetAndRetrievedCorrectly()
        {
            _projectBillingPeriodItem.IsUpdate = true;
            Assert.IsTrue(_projectBillingPeriodItem.IsUpdate);
        }
        
        [Test]
        public void IsDelete_ShouldBeSetAndRetrievedCorrectly()
        {
            _projectBillingPeriodItem.IsDelete = true;
            Assert.IsTrue(_projectBillingPeriodItem.IsDelete);
        }
        
        [Test]
        public void BidEntityno_ShouldNotBeNull()
        {
            Assert.Throws<ArgumentNullException>(() => _projectBillingPeriodItem.BidEntityno = null);
        }
        
        [Test]
        public void Periodno_ShouldBeSetAndRetrievedCorrectly()
        {
            short periodNo = 5;
            _projectBillingPeriodItem.Periodno = periodNo;
            Assert.AreEqual(periodNo, _projectBillingPeriodItem.Periodno);
        }
        
        [Test]
        public void Itemno_ShouldBeSetAndRetrievedCorrectly()
        {
            short itemNo = 10;
            _projectBillingPeriodItem.Itemno = itemNo;
            Assert.AreEqual(itemNo, _projectBillingPeriodItem.Itemno);
        }
        
        [Test]
        public void StartDate_ShouldBeSetAndRetrievedCorrectly()
        {
            DateTime? startDate = DateTime.Now;
            _projectBillingPeriodItem.StartDate = startDate;
            Assert.AreEqual(startDate, _projectBillingPeriodItem.StartDate);
        }
        
        [Test]
        public void EndDate_ShouldBeSetAndRetrievedCorrectly()
        {
            DateTime? endDate = DateTime.Now;
            _projectBillingPeriodItem.EndDate = endDate;
            Assert.AreEqual(endDate, _projectBillingPeriodItem.EndDate);
        }
        
        [Test]
        public void AdjustedWeekly_ShouldBeSetAndRetrievedCorrectly()
        {
            decimal? adjustedWeekly = 100.50m;
            _projectBillingPeriodItem.AdjustedWeekly = adjustedWeekly;
            Assert.AreEqual(adjustedWeekly, _projectBillingPeriodItem.AdjustedWeekly);
        }
        
        [Test]
        public void IsActive_ShouldBeSetAndRetrievedCorrectly()
        {
            int isActive = 1;
            _projectBillingPeriodItem.IsActive = isActive;
            Assert.AreEqual(isActive, _projectBillingPeriodItem.IsActive);
        }
        
        [Test]
        public void BillingDays_ShouldBeSetAndRetrievedCorrectly()
        {
            double? billingDays = 5.5;
            _projectBillingPeriodItem.BillingDays = billingDays;
            Assert.AreEqual(billingDays, _projectBillingPeriodItem.BillingDays);
        }
        
        [Test]
        public void ActualDailyRate_ShouldBeSetAndRetrievedCorrectly()
        {
            double actualDailyRate = 200.75;
            _projectBillingPeriodItem.ActualDailyRate = actualDailyRate;
            Assert.AreEqual(actualDailyRate, _projectBillingPeriodItem.ActualDailyRate);
        }
    }
}