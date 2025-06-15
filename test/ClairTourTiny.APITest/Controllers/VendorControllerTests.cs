using System.Collections.Generic;
using System.Threading.Tasks;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace ClairTourTiny.API.Tests.Controllers;
public class VendorControllerTests
{
    private readonly Mock<IVendorService> _mockVendorService;
    private readonly Mock<ILogger<VendorController>> _mockLogger;
    private readonly VendorController _controller;
    public VendorControllerTests()
    {
        _mockVendorService = new Mock<IVendorService>();
        _mockLogger = new Mock<ILogger<VendorController>>();
        _controller = new VendorController(_mockVendorService.Object, _mockLogger.Object);
    }
    [Fact]
    public async Task GetKnownVendors_ReturnsOkResult_WithListOfVendors()
    {
        // Arrange
        var partNo = "123";
        var vendors = new List<VendorDto> { new VendorDto() };
        _mockVendorService.Setup(s => s.GetKnownVendorsAsync(partNo)).ReturnsAsync(vendors);
        // Act
        var result = await _controller.GetKnownVendors(partNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(vendors, okResult.Value);
    }
    [Fact]
    public async Task GetKnownVendors_ReturnsBadRequest_WhenPartNoIsNull()
    {
        // Act
        var result = await _controller.GetKnownVendors(null);
        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    [Fact]
    public async Task GetKnownVendors_ReturnsInternalServerError_OnException()
    {
        // Arrange
        var partNo = "123";
        _mockVendorService.Setup(s => s.GetKnownVendorsAsync(partNo)).ThrowsAsync(new System.Exception());
        // Act
        var result = await _controller.GetKnownVendors(partNo);
        // Assert
        Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, ((ObjectResult)result.Result).StatusCode);
    }
    [Fact]
    public async Task AddKnownVendor_ReturnsOkResult_WhenVendorIsAdded()
    {
        // Arrange
        var request = new AddKnownVendorRequestDto { PartNo = "123", VendNo = "456", SiteNo = "789" };
        _mockVendorService.Setup(s => s.IsKnownVendorAsync(request.PartNo, request.VendNo, request.SiteNo)).ReturnsAsync(false);
        _mockVendorService.Setup(s => s.AddKnownVendorAsync(request)).ReturnsAsync(true);
        // Act
        var result = await _controller.AddKnownVendor(request);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.True((bool)okResult.Value);
    }
    [Fact]
    public async Task AddKnownVendor_ReturnsBadRequest_WhenRequestIsNull()
    {
        // Act
        var result = await _controller.AddKnownVendor(null);
        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    [Fact]
    public async Task AddKnownVendor_ReturnsBadRequest_WhenVendorIsAlreadyKnown()
    {
        // Arrange
        var request = new AddKnownVendorRequestDto { PartNo = "123", VendNo = "456", SiteNo = "789" };
        _mockVendorService.Setup(s => s.IsKnownVendorAsync(request.PartNo, request.VendNo, request.SiteNo)).ReturnsAsync(true);
        // Act
        var result = await _controller.AddKnownVendor(request);
        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    [Fact]
    public async Task IsKnownVendor_ReturnsOkResult_WithTrue_WhenVendorIsKnown()
    {
        // Arrange
        var partNo = "123";
        var vendNo = "456";
        var siteNo = "789";
        _mockVendorService.Setup(s => s.IsKnownVendorAsync(partNo, vendNo, siteNo)).ReturnsAsync(true);
        // Act
        var result = await _controller.IsKnownVendor(partNo, vendNo, siteNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.True((bool)okResult.Value);
    }
    [Fact]
    public async Task IsKnownVendor_ReturnsBadRequest_WhenParametersAreInvalid()
    {
        // Act
        var result = await _controller.IsKnownVendor(null, null, null);
        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    [Fact]
    public async Task GetVendorAddresses_ReturnsOkResult_WithListOfAddresses()
    {
        // Arrange
        var vendNo = "456";
        var addresses = new List<VendorAddressDto> { new VendorAddressDto() };
        _mockVendorService.Setup(s => s.GetVendorAddressesAsync(vendNo)).ReturnsAsync(addresses);
        // Act
        var result = await _controller.GetVendorAddresses(vendNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(addresses, okResult.Value);
    }
    [Fact]
    public async Task GetVendorAddresses_ReturnsBadRequest_WhenVendNoIsNull()
    {
        // Act
        var result = await _controller.GetVendorAddresses(null);
        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    [Fact]
    public async Task GetSubhireStatuses_ReturnsOkResult_WithListOfStatuses()
    {
        // Arrange
        var statuses = new List<EquipmentSubhireStatusDto> { new EquipmentSubhireStatusDto() };
        _mockVendorService.Setup(s => s.GetSubhireStatusesAsync()).ReturnsAsync(statuses);
        // Act
        var result = await _controller.GetSubhireStatuses();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(statuses, okResult.Value);
    }
    [Fact]
    public async Task GetRateTypes_ReturnsOkResult_WithListOfRateTypes()
    {
        // Arrange
        var rateTypes = new List<RateTypeDto> { new RateTypeDto() };
        _mockVendorService.Setup(s => s.GetRateTypesAsync()).ReturnsAsync(rateTypes);
        // Act
        var result = await _controller.GetRateTypes();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(rateTypes, okResult.Value);
    }
}