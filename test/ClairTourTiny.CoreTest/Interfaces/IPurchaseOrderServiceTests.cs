using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
namespace ClairTourTiny.Tests
{
    public class PurchaseOrderServiceTests
    {
        private readonly Mock<IPurchaseOrderService> _mockPurchaseOrderService;
        public PurchaseOrderServiceTests()
        {
            _mockPurchaseOrderService = new Mock<IPurchaseOrderService>();
        }
        [Fact]
        public async Task GetPurchaseOrdersByProjectAsync_ShouldReturnPurchaseOrders()
        {
            // Arrange
            var entityNo = "Project123";
            var expectedOrders = new List<PurchaseOrderDto>
            {
                new PurchaseOrderDto { /* Initialize properties */ },
                new PurchaseOrderDto { /* Initialize properties */ }
            };
            _mockPurchaseOrderService.Setup(service => service.GetPurchaseOrdersByProjectAsync(entityNo))
                .ReturnsAsync(expectedOrders);
            // Act
            var result = await _mockPurchaseOrderService.Object.GetPurchaseOrdersByProjectAsync(entityNo);
            // Assert
            Assert.Equal(expectedOrders, result);
        }
        [Fact]
        public async Task CreatePurchaseOrderAsync_ShouldReturnCreatePurchaseOrderResponse()
        {
            // Arrange
            var request = new CreatePurchaseOrderRequest { /* Initialize properties */ };
            var expectedResponse = new CreatePurchaseOrderResponse { /* Initialize properties */ };
            _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
                .ReturnsAsync(expectedResponse);
            // Act
            var result = await _mockPurchaseOrderService.Object.CreatePurchaseOrderAsync(request);
            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}