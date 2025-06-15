using NUnit.Framework;
using Moq;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using System.Collections.Generic;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class BidSummaryResponseTests
    {
        private Mock<EquipmentSummaryResponse> _mockEquipment;
        private Mock<CrewSummaryResponse> _mockCrew;
        private Mock<ExpenseSummaryResponse> _mockExpenses;
        private Mock<List<ProjectBillingPeriodModel>> _mockBillingPeriods;
        private Mock<List<ProjectBillingPeriodItemModel>> _mockBillingPeriodItems;

        [SetUp]
        public void Setup()
        {
            _mockEquipment = new Mock<EquipmentSummaryResponse>();
            _mockCrew = new Mock<CrewSummaryResponse>();
            _mockExpenses = new Mock<ExpenseSummaryResponse>();
            _mockBillingPeriods = new Mock<List<ProjectBillingPeriodModel>>();
            _mockBillingPeriodItems = new Mock<List<ProjectBillingPeriodItemModel>>();
        }

        [Test]
        public void BidSummaryResponse_DefaultInitialization_ShouldInitializeProperties()
        {
            // Arrange & Act
            var bidSummary = new BidSummaryResponse();

            // Assert
            Assert.IsNotNull(bidSummary.Equipment);
            Assert.IsNotNull(bidSummary.Crew);
            Assert.IsNotNull(bidSummary.Expenses);
            Assert.IsNotNull(bidSummary.BillingPeriods);
            Assert.IsNotNull(bidSummary.BillingPeriodItems);
            Assert.AreEqual(0, bidSummary.WeeklyTotal);
            Assert.AreEqual(0, bidSummary.GrandTotal);
            Assert.AreEqual(0, bidSummary.BenchmarkTotal);
            Assert.AreEqual(0, bidSummary.QuoteMinGrandTotal);
            Assert.AreEqual(0, bidSummary.QuoteEquipmentValue);
            Assert.AreEqual(0, bidSummary.OverrideMarkupPercentage);
            Assert.AreEqual(0, bidSummary.ProposedWeekly);
            Assert.AreEqual(0, bidSummary.ProposedTotal);
            Assert.IsFalse(bidSummary.RevenueOnSalesForecast);
            Assert.AreEqual(0, bidSummary.DefaultMarkupPercentage);
        }

        [Test]
        public void BidSummaryResponse_SetProperties_ShouldRetainValues()
        {
            // Arrange
            var bidSummary = new BidSummaryResponse
            {
                Equipment = _mockEquipment.Object,
                Crew = _mockCrew.Object,
                Expenses = _mockExpenses.Object,
                BillingPeriods = _mockBillingPeriods.Object,
                BillingPeriodItems = _mockBillingPeriodItems.Object,
                WeeklyTotal = 100.0,
                GrandTotal = 200.0,
                BenchmarkTotal = 300.0,
                QuoteMinGrandTotal = 400.0,
                QuoteEquipmentValue = 500.0,
                OverrideMarkupPercentage = 10.0,
                ProposedWeekly = 600.0,
                ProposedTotal = 700.0,
                RevenueOnSalesForecast = true,
                DefaultMarkupPercentage = 15.0
            };

            // Act & Assert
            Assert.AreEqual(_mockEquipment.Object, bidSummary.Equipment);
            Assert.AreEqual(_mockCrew.Object, bidSummary.Crew);
            Assert.AreEqual(_mockExpenses.Object, bidSummary.Expenses);
            Assert.AreEqual(_mockBillingPeriods.Object, bidSummary.BillingPeriods);
            Assert.AreEqual(_mockBillingPeriodItems.Object, bidSummary.BillingPeriodItems);
            Assert.AreEqual(100.0, bidSummary.WeeklyTotal);
            Assert.AreEqual(200.0, bidSummary.GrandTotal);
            Assert.AreEqual(300.0, bidSummary.BenchmarkTotal);
            Assert.AreEqual(400.0, bidSummary.QuoteMinGrandTotal);
            Assert.AreEqual(500.0, bidSummary.QuoteEquipmentValue);
            Assert.AreEqual(10.0, bidSummary.OverrideMarkupPercentage);
            Assert.AreEqual(600.0, bidSummary.ProposedWeekly);
            Assert.AreEqual(700.0, bidSummary.ProposedTotal);
            Assert.IsTrue(bidSummary.RevenueOnSalesForecast);
            Assert.AreEqual(15.0, bidSummary.DefaultMarkupPercentage);
        }
    }
}