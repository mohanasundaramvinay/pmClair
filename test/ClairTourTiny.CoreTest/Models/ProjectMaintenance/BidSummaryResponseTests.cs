using NUnit.Framework;
using Moq;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using System.Collections.Generic;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class BidSummaryResponseTests
    {
        [Test]
        public void Equipment_ShouldBeInitialized()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.IsNotNull(bidSummary.Equipment);
        }

        [Test]
        public void Crew_ShouldBeInitialized()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.IsNotNull(bidSummary.Crew);
        }

        [Test]
        public void Expenses_ShouldBeInitialized()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.IsNotNull(bidSummary.Expenses);
        }

        [Test]
        public void BillingPeriods_ShouldBeInitialized()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.IsNotNull(bidSummary.BillingPeriods);
        }

        [Test]
        public void BillingPeriodItems_ShouldBeInitialized()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.IsNotNull(bidSummary.BillingPeriodItems);
        }

        [Test]
        public void WeeklyTotal_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.WeeklyTotal);
        }

        [Test]
        public void GrandTotal_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.GrandTotal);
        }

        [Test]
        public void BenchmarkTotal_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.BenchmarkTotal);
        }

        [Test]
        public void QuoteMinGrandTotal_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.QuoteMinGrandTotal);
        }

        [Test]
        public void QuoteEquipmentValue_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.QuoteEquipmentValue);
        }

        [Test]
        public void OverrideMarkupPercentage_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.OverrideMarkupPercentage);
        }

        [Test]
        public void ProposedWeekly_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.ProposedWeekly);
        }

        [Test]
        public void ProposedTotal_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.ProposedTotal);
        }

        [Test]
        public void RevenueOnSalesForecast_ShouldBeFalseByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.IsFalse(bidSummary.RevenueOnSalesForecast);
        }

        [Test]
        public void DefaultMarkupPercentage_ShouldBeZeroByDefault()
        {
            var bidSummary = new BidSummaryResponse();
            Assert.AreEqual(0, bidSummary.DefaultMarkupPercentage);
        }
    }
}