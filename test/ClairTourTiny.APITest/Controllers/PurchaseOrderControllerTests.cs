using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClairTourTiny.API.Controllers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Infrastructure.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace ClairTourTiny.Tests
{
    public class PurchaseOrderControllerTests
    {
        private readonly Mock<IPurchaseOrderService> _mockPurchaseOrderService;
        private readonly PurchaseOrderController _controller;
        public PurchaseOrderControllerTests()
        {
            _mockPurchaseOrderService = new Mock<IPurchaseOrderService>();
            _controller = new PurchaseOrderController(_mockPurchaseOrderService.Object);
        }
        [Fact]
        public async Task GetPurchaseOrdersByProject_ReturnsOkResult_WithPurchaseOrders()
        {
            // Arrange
            var entityNo = "123";
            var purchaseOrders = new List<PurchaseOrderDto>
            {
                new PurchaseOrderDto { IdPurchaseOrder = 1, PONumber = 1001, PODescription = "Test PO", Currency = "USD", TotalAmount = 100.0m }
            };
            _mockPurchaseOrderService.Setup(service => service.GetPurchaseOrdersByProjectAsync(entityNo))
                .ReturnsAsync(purchaseOrders);
            // Act
            var result = await _controller.GetPurchaseOrdersByProject(entityNo);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PurchaseOrderDto>>(okResult.Value);
            Assert.Single(returnValue);
        }
        [Fact]
        public async Task GetPurchaseOrdersByProject_ReturnsStatusCode500_OnServiceException()
        {
            // Arrange
            var entityNo = "123";
            _mockPurchaseOrderService.Setup(service => service.GetPurchaseOrdersByProjectAsync(entityNo))
                .ThrowsAsync(new PurchaseOrderServiceException("Service error"));
            // Act
            var result = await _controller.GetPurchaseOrdersByProject(entityNo);
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task CreatePurchaseOrder_ReturnsCreatedAtActionResult_WithCreatedPurchaseOrder()
        {
            // Arrange
            var request = new CreatePurchaseOrderRequest { EntityNo = "123", PODescription = "New PO" };
            var response = new CreatePurchaseOrderResponse { PONumber = 1002 };
            _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
                .ReturnsAsync(response);
            // Act
            var result = await _controller.CreatePurchaseOrder(request);
            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<CreatePurchaseOrderResponse>(createdAtActionResult.Value);
            Assert.Equal(response.PONumber, returnValue.PONumber);
        }
        [Fact]
        public async Task CreatePurchaseOrder_ReturnsBadRequest_OnValidationException()
        {
            // Arrange
            var request = new CreatePurchaseOrderRequest { EntityNo = "123", PODescription = "New PO" };
            _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
                .ThrowsAsync(new PurchaseOrderValidationException("Validation error"));
            // Act
            var result = await _controller.CreatePurchaseOrder(request);
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Validation error", badRequestResult.Value);
        }
        [Fact]
        public async Task CreatePurchaseOrder_ReturnsStatusCode500_OnServiceException()
        {
            // Arrange
            var request = new CreatePurchaseOrderRequest { EntityNo = "123", PODescription = "New PO" };
            _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
                .ThrowsAsync(new PurchaseOrderServiceException("Service error"));
            // Act
            var result = await _controller.CreatePurchaseOrder(request);
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}