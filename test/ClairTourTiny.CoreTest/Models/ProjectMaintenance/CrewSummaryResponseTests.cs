using System.Collections.Generic;
using Xunit;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Core.Models.ProjectMaintenance
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
        public void CrewSummaryResponse_InitializesWithNonNullSubtotal()
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
            var item = new ItemSummary(); // Assuming ItemSummary has a parameterless constructor

            // Act
            response.Items.Add(item);

            // Assert
            Assert.Single(response.Items);
            Assert.Contains(item, response.Items);
        }
    }
}