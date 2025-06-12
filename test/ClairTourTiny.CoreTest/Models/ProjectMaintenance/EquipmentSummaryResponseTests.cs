using System.Collections.Generic;
using Xunit;
using Moq;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class EquipmentSummaryResponseTests
    {
        [Fact]
        public void EquipmentSummaryResponse_ShouldInitializeItemsList()
        {
            // Arrange & Act
            var response = new EquipmentSummaryResponse();
            
            // Assert
            Assert.NotNull(response.Items);
            Assert.Empty(response.Items);
        }
        
        [Fact]
        public void EquipmentSummaryResponse_ShouldInitializeSubtotal()
        {
            // Arrange & Act
            var response = new EquipmentSummaryResponse();
            
            // Assert
            Assert.NotNull(response.Subtotal);
        }
        
        [Fact]
        public void EquipmentSummaryResponse_ShouldAllowAddingItems()
        {
            // Arrange
            var response = new EquipmentSummaryResponse();
            var mockItem = new Mock<ItemSummary>();
            
            // Act
            response.Items.Add(mockItem.Object);
            
            // Assert
            Assert.Single(response.Items);
            Assert.Contains(mockItem.Object, response.Items);
        }
        
        [Fact]
        public void EquipmentSummaryResponse_ShouldAllowSettingSubtotal()
        {
            // Arrange
            var response = new EquipmentSummaryResponse();
            var mockSubtotal = new Mock<SubtotalSummary>();
            
            // Act
            response.Subtotal = mockSubtotal.Object;
            
            // Assert
            Assert.Equal(mockSubtotal.Object, response.Subtotal);
        }
    }
}