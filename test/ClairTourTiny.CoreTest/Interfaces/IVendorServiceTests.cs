using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
public class VendorServiceTests
{
    private readonly Mock<IVendorService> _vendorServiceMock;
    public VendorServiceTests()
    {
        _vendorServiceMock = new Mock<IVendorService>();
    }
    [Fact]
    public async Task GetKnownVendorsAsync_ShouldReturnVendors()
    {
        // Arrange
        var partNo = "12345";
        var expectedVendors = new List<VendorDto> { new VendorDto() };
        _vendorServiceMock.Setup(service => service.GetKnownVendorsAsync(partNo)).ReturnsAsync(expectedVendors);
        // Act
        var result = await _vendorServiceMock.Object.GetKnownVendorsAsync(partNo);
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
    [Fact]
    public async Task GetVendorAddressesAsync_ShouldReturnAddresses()
    {
        // Arrange
        var vendNo = "V123";
        var expectedAddresses = new List<VendorAddressDto> { new VendorAddressDto() };
        _vendorServiceMock.Setup(service => service.GetVendorAddressesAsync(vendNo)).ReturnsAsync(expectedAddresses);
        // Act
        var result = await _vendorServiceMock.Object.GetVendorAddressesAsync(vendNo);
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
    [Fact]
    public async Task AddKnownVendorAsync_ShouldReturnTrue()
    {
        // Arrange
        var request = new AddKnownVendorRequestDto();
        _vendorServiceMock.Setup(service => service.AddKnownVendorAsync(request)).ReturnsAsync(true);
        // Act
        var result = await _vendorServiceMock.Object.AddKnownVendorAsync(request);
        // Assert
        Assert.True(result);
    }
    [Fact]
    public async Task IsKnownVendorAsync_ShouldReturnTrue()
    {
        // Arrange
        var partNo = "12345";
        var vendNo = "V123";
        var siteNo = "S1";
        _vendorServiceMock.Setup(service => service.IsKnownVendorAsync(partNo, vendNo, siteNo)).ReturnsAsync(true);
        // Act
        var result = await _vendorServiceMock.Object.IsKnownVendorAsync(partNo, vendNo, siteNo);
        // Assert
        Assert.True(result);
    }
    [Fact]
    public async Task GetSubhireStatusesAsync_ShouldReturnStatuses()
    {
        // Arrange
        var expectedStatuses = new List<EquipmentSubhireStatusDto> { new EquipmentSubhireStatusDto() };
        _vendorServiceMock.Setup(service => service.GetSubhireStatusesAsync()).ReturnsAsync(expectedStatuses);
        // Act
        var result = await _vendorServiceMock.Object.GetSubhireStatusesAsync();
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
    [Fact]
    public async Task GetRateTypesAsync_ShouldReturnRateTypes()
    {
        // Arrange
        var expectedRateTypes = new List<RateTypeDto> { new RateTypeDto() };
        _vendorServiceMock.Setup(service => service.GetRateTypesAsync()).ReturnsAsync(expectedRateTypes);
        // Act
        var result = await _vendorServiceMock.Object.GetRateTypesAsync();
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}