using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class ProjectBillingPeriodTests
    {
        [Test]
        public void UpdateTime_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            var updateTime = DateTime.Now;
            projectBillingPeriod.UpdateTime = updateTime;
            Assert.AreEqual(updateTime, projectBillingPeriod.UpdateTime);
        }

        [Test]
        public void IsInsert_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            projectBillingPeriod.IsInsert = true;
            Assert.IsTrue(projectBillingPeriod.IsInsert);
        }

        [Test]
        public void IsUpdate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            projectBillingPeriod.IsUpdate = true;
            Assert.IsTrue(projectBillingPeriod.IsUpdate);
        }

        [Test]
        public void IsDelete_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            projectBillingPeriod.IsDelete = true;
            Assert.IsTrue(projectBillingPeriod.IsDelete);
        }

        [Test]
        public void BidEntityno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            var bidEntityno = "BID123";
            projectBillingPeriod.BidEntityno = bidEntityno;
            Assert.AreEqual(bidEntityno, projectBillingPeriod.BidEntityno);
        }

        [Test]
        public void Periodno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            short periodno = 1;
            projectBillingPeriod.Periodno = periodno;
            Assert.AreEqual(periodno, projectBillingPeriod.Periodno);
        }

        [Test]
        public void StartDate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            var startDate = DateTime.Now;
            projectBillingPeriod.StartDate = startDate;
            Assert.AreEqual(startDate, projectBillingPeriod.StartDate);
        }

        [Test]
        public void EndDate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            var endDate = DateTime.Now;
            projectBillingPeriod.EndDate = endDate;
            Assert.AreEqual(endDate, projectBillingPeriod.EndDate);
        }

        [Test]
        public void PeriodTitle_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            var periodTitle = "Q1 2023";
            projectBillingPeriod.PeriodTitle = periodTitle;
            Assert.AreEqual(periodTitle, projectBillingPeriod.PeriodTitle);
        }

        [Test]
        public void IsActive_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            projectBillingPeriod.IsActive = true;
            Assert.IsTrue(projectBillingPeriod.IsActive);
        }

        [Test]
        public void ShowOnQuoteReport_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            projectBillingPeriod.ShowOnQuoteReport = true;
            Assert.IsTrue(projectBillingPeriod.ShowOnQuoteReport);
        }

        [Test]
        public void DisplayOrder_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            int? displayOrder = 5;
            projectBillingPeriod.DisplayOrder = displayOrder;
            Assert.AreEqual(displayOrder, projectBillingPeriod.DisplayOrder);
        }
    }
}