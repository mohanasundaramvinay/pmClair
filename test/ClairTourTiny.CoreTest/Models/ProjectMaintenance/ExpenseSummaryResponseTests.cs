using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class ExpenseSummaryResponseTests
    {
        [Test]
        public void ExpenseSummaryResponse_InitializesProperties()
        {
            // Arrange & Act
            var expenseSummaryResponse = new ExpenseSummaryResponse();

            // Assert
            Assert.IsNotNull(expenseSummaryResponse.WeeklyExpensesSubtotal);
            Assert.IsNotNull(expenseSummaryResponse.SingleExpensesSubtotal);
            Assert.IsNotNull(expenseSummaryResponse.WeeklyExpenses);
            Assert.IsNotNull(expenseSummaryResponse.SingleExpenses);
            Assert.IsEmpty(expenseSummaryResponse.WeeklyExpenses);
            Assert.IsEmpty(expenseSummaryResponse.SingleExpenses);
        }
    }
}