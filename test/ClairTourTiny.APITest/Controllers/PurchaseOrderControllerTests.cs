using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClairTourTiny.API.Controllers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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
        var entityNo = "12345";
        var purchaseOrders = new List<PurchaseOrderDto>
        {
            new PurchaseOrderDto { IdPurchaseOrder = 1, PONumber = 1001, PODescription = "Test PO 1", Currency = "USD", TotalAmount = 100.00m },
            new PurchaseOrderDto { IdPurchaseOrder = 2, PONumber = 1002, PODescription = "Test PO 2", Currency = "USD", TotalAmount = 200.00m }
        };
        _mockPurchaseOrderService.Setup(service => service.GetPurchaseOrdersByProjectAsync(entityNo))
            .ReturnsAsync(purchaseOrders);
        // Act
        var result = await _controller.GetPurchaseOrdersByProject(entityNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<PurchaseOrderDto>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }
    [Fact]
    public async Task GetPurchaseOrdersByProject_ReturnsStatusCode500_WhenServiceThrowsException()
    {
        // Arrange
        var entityNo = "12345";
        _mockPurchaseOrderService.Setup(service => service.GetPurchaseOrdersByProjectAsync(entityNo))
            .ThrowsAsync(new PurchaseOrderServiceException("Service error"));
        // Act
        var result = await _controller.GetPurchaseOrdersByProject(entityNo);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task RefreshPurchaseOrders_ReturnsOkResult_WithRefreshMetadata()
    {
        // Arrange
        var entityNo = "12345";
        var purchaseOrders = new List<PurchaseOrderDto>
        {
            new PurchaseOrderDto { IdPurchaseOrder = 1, PONumber = 1001, PODescription = "Test PO 1", Currency = "USD", TotalAmount = 100.00m }
        };
        _mockPurchaseOrderService.Setup(service => service.RefreshPurchaseOrdersAsync(entityNo))
            .ReturnsAsync(purchaseOrders);
        // Act
        var result = await _controller.RefreshPurchaseOrders(entityNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<dynamic>(okResult.Value);
        Assert.True(returnValue.Success);
        Assert.Equal(1, ((IEnumerable<PurchaseOrderDto>)returnValue.Data).Count());
    }
    [Fact]
    public async Task RefreshPurchaseOrders_ReturnsStatusCode500_WhenServiceThrowsException()
    {
        // Arrange
        var entityNo = "12345";
        _mockPurchaseOrderService.Setup(service => service.RefreshPurchaseOrdersAsync(entityNo))
            .ThrowsAsync(new PurchaseOrderServiceException("Service error"));
        // Act
        var result = await _controller.RefreshPurchaseOrders(entityNo);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task CreatePurchaseOrder_ReturnsCreatedAtActionResult_WithCreatedPONumber()
    {
        // Arrange
        var request = new CreatePurchaseOrderRequest { EntityNo = "12345", PODescription = "New PO" };
        var response = new CreatePurchaseOrderResponse { PONumber = 1003 };
        _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
            .ReturnsAsync(response);
        // Act
        var result = await _controller.CreatePurchaseOrder(request);
        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<CreatePurchaseOrderResponse>(createdAtActionResult.Value);
        Assert.Equal(1003, returnValue.PONumber);
    }
    [Fact]
    public async Task CreatePurchaseOrder_ReturnsBadRequest_WhenValidationExceptionThrown()
    {
        // Arrange
        var request = new CreatePurchaseOrderRequest { EntityNo = "12345", PODescription = "New PO" };
        _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
            .ThrowsAsync(new PurchaseOrderValidationException("Validation error"));
        // Act
        var result = await _controller.CreatePurchaseOrder(request);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Validation error", badRequestResult.Value);
    }
    [Fact]
    public async Task CreatePurchaseOrder_ReturnsStatusCode500_WhenServiceThrowsException()
    {
        // Arrange
        var request = new CreatePurchaseOrderRequest { EntityNo = "12345", PODescription = "New PO" };
        _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
            .ThrowsAsync(new PurchaseOrderServiceException("Service error"));
        // Act
        var result = await _controller.CreatePurchaseOrder(request);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}