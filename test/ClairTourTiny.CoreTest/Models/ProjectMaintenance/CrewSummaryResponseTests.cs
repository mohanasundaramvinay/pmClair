using System.Collections.Generic;
using Xunit;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class CrewSummaryResponseTests
    {
        [Fact]
        public void CrewSummaryResponse_InitializesWithEmptyItemsList()
        {
            // Arrange & Act
            var response = new CrewSummaryResponse();

            // Assert
            Assert.NotNull(response.Items);
            Assert.Empty(response.Items);
        }

        [Fact]
        public void CrewSummaryResponse_InitializesWithSubtotal()
        {
            // Arrange & Act
            var response = new CrewSummaryResponse();

            // Assert
            Assert.NotNull(response.Subtotal);
        }

        [Fact]
        public void CrewSummaryResponse_CanAddItemsToList()
        {
            // Arrange
            var response = new CrewSummaryResponse();
            var item = new ItemSummary();

            // Act
            response.Items.Add(item);

            // Assert
            Assert.Single(response.Items);
            Assert.Contains(item, response.Items);
        }
    }
}

// Note: ItemSummary and SubtotalSummary classes need to be defined or mocked if they have specific behaviors to test.