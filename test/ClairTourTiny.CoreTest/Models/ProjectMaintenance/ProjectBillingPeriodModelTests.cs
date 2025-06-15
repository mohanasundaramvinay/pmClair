using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectBillingPeriodModelTests
    {
        [Test]
        public void BidEntityNo_DefaultValue_ShouldBeEmptyString()
        {
            var model = new ProjectBillingPeriodModel();
            Assert.AreEqual(string.Empty, model.BidEntityNo);
        }

        [Test]
        public void PeriodNo_ShouldSetAndGetCorrectly()
        {
            var model = new ProjectBillingPeriodModel();
            model.PeriodNo = 5;
            Assert.AreEqual(5, model.PeriodNo);
        }

        [Test]
        public void StartDate_ShouldSetAndGetCorrectly()
        {
            var model = new ProjectBillingPeriodModel();
            var date = new DateTime(2023, 10, 1);
            model.StartDate = date;
            Assert.AreEqual(date, model.StartDate);
        }

        [Test]
        public void EndDate_ShouldSetAndGetCorrectly()
        {
            var model = new ProjectBillingPeriodModel();
            var date = new DateTime(2023, 10, 31);
            model.EndDate = date;
            Assert.AreEqual(date, model.EndDate);
        }

        [Test]
        public void PeriodTitle_DefaultValue_ShouldBeEmptyString()
        {
            var model = new ProjectBillingPeriodModel();
            Assert.AreEqual(string.Empty, model.PeriodTitle);
        }

        [Test]
        public void IsActive_ShouldSetAndGetCorrectly()
        {
            var model = new ProjectBillingPeriodModel();
            model.IsActive = true;
            Assert.IsTrue(model.IsActive);
        }

        [Test]
        public void ShowOnQuoteReport_ShouldSetAndGetCorrectly()
        {
            var model = new ProjectBillingPeriodModel();
            model.ShowOnQuoteReport = true;
            Assert.IsTrue(model.ShowOnQuoteReport);
        }

        [Test]
        public void DisplayOrder_ShouldSetAndGetCorrectly()
        {
            var model = new ProjectBillingPeriodModel();
            model.DisplayOrder = 1;
            Assert.AreEqual(1, model.DisplayOrder);
        }

        [Test]
        public void DisplayOrder_CanBeNull()
        {
            var model = new ProjectBillingPeriodModel();
            model.DisplayOrder = null;
            Assert.IsNull(model.DisplayOrder);
        }
    }
}