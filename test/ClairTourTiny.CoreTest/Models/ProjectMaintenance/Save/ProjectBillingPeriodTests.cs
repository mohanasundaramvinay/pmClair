using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class ProjectBillingPeriodTests
    {
        [Test]
        public void ProjectBillingPeriod_CanBeInstantiated()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            Assert.IsNotNull(projectBillingPeriod);
        }
        [Test]
        public void ProjectBillingPeriod_DefaultValues_AreCorrect()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            Assert.AreEqual(default(DateTime), projectBillingPeriod.UpdateTime);
            Assert.IsFalse(projectBillingPeriod.IsInsert);
            Assert.IsFalse(projectBillingPeriod.IsUpdate);
            Assert.IsFalse(projectBillingPeriod.IsDelete);
            Assert.AreEqual(null, projectBillingPeriod.BidEntityno);
            Assert.AreEqual(default(short), projectBillingPeriod.Periodno);
            Assert.AreEqual(default(DateTime), projectBillingPeriod.StartDate);
            Assert.AreEqual(default(DateTime), projectBillingPeriod.EndDate);
            Assert.AreEqual(null, projectBillingPeriod.PeriodTitle);
            Assert.IsFalse(projectBillingPeriod.IsActive);
            Assert.IsFalse(projectBillingPeriod.ShowOnQuoteReport);
            Assert.AreEqual(null, projectBillingPeriod.DisplayOrder);
        }
        [Test]
        public void ProjectBillingPeriod_Properties_CanBeSetAndRetrieved()
        {
            var projectBillingPeriod = new ProjectBillingPeriod();
            var updateTime = DateTime.Now;
            var bidEntityno = "12345";
            var periodno = (short)1;
            var startDate = new DateTime(2023, 1, 1);
            var endDate = new DateTime(2023, 12, 31);
            var periodTitle = "Q1 2023";
            var isActive = true;
            var showOnQuoteReport = true;
            var displayOrder = 1;
            projectBillingPeriod.UpdateTime = updateTime;
            projectBillingPeriod.IsInsert = true;
            projectBillingPeriod.IsUpdate = true;
            projectBillingPeriod.IsDelete = true;
            projectBillingPeriod.BidEntityno = bidEntityno;
            projectBillingPeriod.Periodno = periodno;
            projectBillingPeriod.StartDate = startDate;
            projectBillingPeriod.EndDate = endDate;
            projectBillingPeriod.PeriodTitle = periodTitle;
            projectBillingPeriod.IsActive = isActive;
            projectBillingPeriod.ShowOnQuoteReport = showOnQuoteReport;
            projectBillingPeriod.DisplayOrder = displayOrder;
            Assert.AreEqual(updateTime, projectBillingPeriod.UpdateTime);
            Assert.IsTrue(projectBillingPeriod.IsInsert);
            Assert.IsTrue(projectBillingPeriod.IsUpdate);
            Assert.IsTrue(projectBillingPeriod.IsDelete);
            Assert.AreEqual(bidEntityno, projectBillingPeriod.BidEntityno);
            Assert.AreEqual(periodno, projectBillingPeriod.Periodno);
            Assert.AreEqual(startDate, projectBillingPeriod.StartDate);
            Assert.AreEqual(endDate, projectBillingPeriod.EndDate);
            Assert.AreEqual(periodTitle, projectBillingPeriod.PeriodTitle);
            Assert.IsTrue(projectBillingPeriod.IsActive);
            Assert.IsTrue(projectBillingPeriod.ShowOnQuoteReport);
            Assert.AreEqual(displayOrder, projectBillingPeriod.DisplayOrder);
        }
    }
}