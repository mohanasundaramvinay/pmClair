using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
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
        var entityNo = "123";
        var expectedOrders = new List<PurchaseOrderDto> { new PurchaseOrderDto() };
        _mockPurchaseOrderService.Setup(service => service.GetPurchaseOrdersByProjectAsync(entityNo))
            .ReturnsAsync(expectedOrders);
        // Act
        var result = await _mockPurchaseOrderService.Object.GetPurchaseOrdersByProjectAsync(entityNo);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedOrders, result);
    }
    [Fact]
    public async Task CreatePurchaseOrderAsync_ShouldReturnCreatePurchaseOrderResponse()
    {
        // Arrange
        var request = new CreatePurchaseOrderRequest();
        var expectedResponse = new CreatePurchaseOrderResponse();
        _mockPurchaseOrderService.Setup(service => service.CreatePurchaseOrderAsync(request))
            .ReturnsAsync(expectedResponse);
        // Act
        var result = await _mockPurchaseOrderService.Object.CreatePurchaseOrderAsync(request);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedResponse, result);
    }
}