using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ExpenseSummaryResponseTests
    {
        [Test]
        public void WeeklyExpensesSubtotal_ShouldInitializeAsNewSubtotalSummary()
        {
            // Arrange & Act
            var expenseSummaryResponse = new ExpenseSummaryResponse();

            // Assert
            Assert.IsNotNull(expenseSummaryResponse.WeeklyExpensesSubtotal);
        }

        [Test]
        public void SingleExpensesSubtotal_ShouldInitializeAsNewSubtotalSummary()
        {
            // Arrange & Act
            var expenseSummaryResponse = new ExpenseSummaryResponse();

            // Assert
            Assert.IsNotNull(expenseSummaryResponse.SingleExpensesSubtotal);
        }

        [Test]
        public void WeeklyExpenses_ShouldInitializeAsEmptyList()
        {
            // Arrange & Act
            var expenseSummaryResponse = new ExpenseSummaryResponse();

            // Assert
            Assert.IsNotNull(expenseSummaryResponse.WeeklyExpenses);
            Assert.IsEmpty(expenseSummaryResponse.WeeklyExpenses);
        }

        [Test]
        public void SingleExpenses_ShouldInitializeAsEmptyList()
        {
            // Arrange & Act
            var expenseSummaryResponse = new ExpenseSummaryResponse();

            // Assert
            Assert.IsNotNull(expenseSummaryResponse.SingleExpenses);
            Assert.IsEmpty(expenseSummaryResponse.SingleExpenses);
        }

        [Test]
        public void CanSetAndGetWeeklyExpensesSubtotal()
        {
            // Arrange
            var expenseSummaryResponse = new ExpenseSummaryResponse();
            var mockSubtotalSummary = new Mock<SubtotalSummary>().Object;

            // Act
            expenseSummaryResponse.WeeklyExpensesSubtotal = mockSubtotalSummary;

            // Assert
            Assert.AreEqual(mockSubtotalSummary, expenseSummaryResponse.WeeklyExpensesSubtotal);
        }

        [Test]
        public void CanSetAndGetSingleExpensesSubtotal()
        {
            // Arrange
            var expenseSummaryResponse = new ExpenseSummaryResponse();
            var mockSubtotalSummary = new Mock<SubtotalSummary>().Object;

            // Act
            expenseSummaryResponse.SingleExpensesSubtotal = mockSubtotalSummary;

            // Assert
            Assert.AreEqual(mockSubtotalSummary, expenseSummaryResponse.SingleExpensesSubtotal);
        }

        [Test]
        public void CanSetAndGetWeeklyExpenses()
        {
            // Arrange
            var expenseSummaryResponse = new ExpenseSummaryResponse();
            var mockItemSummaryList = new List<ItemSummary> { new Mock<ItemSummary>().Object };

            // Act
            expenseSummaryResponse.WeeklyExpenses = mockItemSummaryList;

            // Assert
            Assert.AreEqual(mockItemSummaryList, expenseSummaryResponse.WeeklyExpenses);
        }

        [Test]
        public void CanSetAndGetSingleExpenses()
        {
            // Arrange
            var expenseSummaryResponse = new ExpenseSummaryResponse();
            var mockItemSummaryList = new List<ItemSummary> { new Mock<ItemSummary>().Object };

            // Act
            expenseSummaryResponse.SingleExpenses = mockItemSummaryList;

            // Assert
            Assert.AreEqual(mockItemSummaryList, expenseSummaryResponse.SingleExpenses);
        }
    }
}