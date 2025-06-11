using NUnit.Framework;
using System;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectBillingPeriodModelTests
    {
        [Test]
        public void DefaultValues_ShouldBeCorrect()
        {
            var model = new ProjectBillingPeriodModel();
            Assert.AreEqual(string.Empty, model.BidEntityNo);
            Assert.AreEqual(0, model.PeriodNo);
            Assert.AreEqual(default(DateTime), model.StartDate);
            Assert.AreEqual(default(DateTime), model.EndDate);
            Assert.AreEqual(string.Empty, model.PeriodTitle);
            Assert.IsFalse(model.IsActive);
            Assert.IsFalse(model.ShowOnQuoteReport);
            Assert.IsNull(model.DisplayOrder);
        }

        [Test]
        public void Properties_ShouldSetAndGetCorrectly()
        {
            var model = new ProjectBillingPeriodModel();
            model.BidEntityNo = "12345";
            model.PeriodNo = 1;
            model.StartDate = new DateTime(2023, 1, 1);
            model.EndDate = new DateTime(2023, 12, 31);
            model.PeriodTitle = "Q1 2023";
            model.IsActive = true;
            model.ShowOnQuoteReport = true;
            model.DisplayOrder = 10;

            Assert.AreEqual("12345", model.BidEntityNo);
            Assert.AreEqual(1, model.PeriodNo);
            Assert.AreEqual(new DateTime(2023, 1, 1), model.StartDate);
            Assert.AreEqual(new DateTime(2023, 12, 31), model.EndDate);
            Assert.AreEqual("Q1 2023", model.PeriodTitle);
            Assert.IsTrue(model.IsActive);
            Assert.IsTrue(model.ShowOnQuoteReport);
            Assert.AreEqual(10, model.DisplayOrder);
        }
    }
}