using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace ClairTourTiny.Core.Services.Tests
{
    public class VendorServiceTests
    {
        private readonly Mock<ClairTourTinyContext> _mockContext;
        private readonly Mock<ILogger<VendorService>> _mockLogger;
        private readonly VendorService _vendorService;
        public VendorServiceTests()
        {
            _mockContext = new Mock<ClairTourTinyContext>();
            _mockLogger = new Mock<ILogger<VendorService>>();
            _vendorService = new VendorService(_mockContext.Object, _mockLogger.Object);
        }
        [Fact]
        public async Task GetKnownVendorsAsync_ReturnsVendors()
        {
            // Arrange
            var partNo = "123";
            var vendors = new List<PartSubhireVendor>
            {
                new PartSubhireVendor { Partno = partNo, Vendno = "V1", Siteno = "S1", Currency = "USD", Rate = 100, RateType = "D" }
            }.AsQueryable();
            var povendors = new List<Povendor>
            {
                new Povendor { Vendno = "V1", VendorName = "Vendor 1" }
            }.AsQueryable();
            var povendsites = new List<Povendsite>
            {
                new Povendsite { Vendno = "V1", SiteNo = "S1", City = "City1", State = "State1", Country = "Country1", Phone = "1234567890", Contact = "Contact1", Usenet = "email@example.com", Voicemail = "0987654321" }
            }.AsQueryable();
            var mockPartSubhireVendors = new Mock<DbSet<PartSubhireVendor>>();
            var mockPovendors = new Mock<DbSet<Povendor>>();
            var mockPovendsites = new Mock<DbSet<Povendsite>>();
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Provider).Returns(vendors.Provider);
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Expression).Returns(vendors.Expression);
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.ElementType).Returns(vendors.ElementType);
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.GetEnumerator()).Returns(vendors.GetEnumerator());
            mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.Provider).Returns(povendors.Provider);
            mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.Expression).Returns(povendors.Expression);
            mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.ElementType).Returns(povendors.ElementType);
            mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.GetEnumerator()).Returns(povendors.GetEnumerator());
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Provider).Returns(povendsites.Provider);
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Expression).Returns(povendsites.Expression);
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.ElementType).Returns(povendsites.ElementType);
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.GetEnumerator()).Returns(povendsites.GetEnumerator());
            _mockContext.Setup(c => c.PartSubhireVendors).Returns(mockPartSubhireVendors.Object);
            _mockContext.Setup(c => c.Povendors).Returns(mockPovendors.Object);
            _mockContext.Setup(c => c.Povendsites).Returns(mockPovendsites.Object);
            // Act
            var result = await _vendorService.GetKnownVendorsAsync(partNo);
            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("V1", result.First().VendNo);
        }
        [Fact]
        public async Task GetVendorAddressesAsync_ReturnsAddresses()
        {
            // Arrange
            var vendNo = "V1";
            var povendsites = new List<Povendsite>
            {
                new Povendsite { Vendno = vendNo, SiteNo = "S1", Contact = "Contact1", Address1 = "Address1", Address2 = "Address2", Address3 = "Address3", City = "City1", State = "State1", Zipcode = "12345" }
            }.AsQueryable();
            var mockPovendsites = new Mock<DbSet<Povendsite>>();
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Provider).Returns(povendsites.Provider);
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Expression).Returns(povendsites.Expression);
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.ElementType).Returns(povendsites.ElementType);
            mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.GetEnumerator()).Returns(povendsites.GetEnumerator());
            _mockContext.Setup(c => c.Povendsites).Returns(mockPovendsites.Object);
            // Act
            var result = await _vendorService.GetVendorAddressesAsync(vendNo);
            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("S1", result.First().SiteNo);
        }
        [Fact]
        public async Task AddKnownVendorAsync_AddsVendor()
        {
            // Arrange
            var request = new AddKnownVendorRequestDto
            {
                PartNo = "123",
                VendNo = "V1",
                SiteNo = "S1",
                Notes = "Notes",
                Currency = "USD",
                Rate = 100,
                RateType = "D",
                DeliveryRate = 10,
                ReturnRate = 5
            };
            var mockPartSubhireVendors = new Mock<DbSet<PartSubhireVendor>>();
            _mockContext.Setup(c => c.PartSubhireVendors).Returns(mockPartSubhireVendors.Object);
            // Act
            var result = await _vendorService.AddKnownVendorAsync(request);
            // Assert
            Assert.True(result);
            mockPartSubhireVendors.Verify(m => m.AddAsync(It.IsAny<PartSubhireVendor>(), default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }
        [Fact]
        public async Task IsKnownVendorAsync_ReturnsTrueIfVendorExists()
        {
            // Arrange
            var partNo = "123";
            var vendNo = "V1";
            var siteNo = "S1";
            var vendors = new List<PartSubhireVendor>
            {
                new PartSubhireVendor { Partno = partNo, Vendno = vendNo, Siteno = siteNo }
            }.AsQueryable();
            var mockPartSubhireVendors = new Mock<DbSet<PartSubhireVendor>>();
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Provider).Returns(vendors.Provider);
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Expression).Returns(vendors.Expression);
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.ElementType).Returns(vendors.ElementType);
            mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.GetEnumerator()).Returns(vendors.GetEnumerator());
            _mockContext.Setup(c => c.PartSubhireVendors).Returns(mockPartSubhireVendors.Object);
            // Act
            var result = await _vendorService.IsKnownVendorAsync(partNo, vendNo, siteNo);
            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task GetSubhireStatusesAsync_ReturnsStatuses()
        {
            // Arrange
            var statuses = new List<EquipmentSubhireStatus>
            {
                new EquipmentSubhireStatus { StatusCode = "P", SortOrder = 1 }
            }.AsQueryable();
            var mockEquipmentSubhireStatuses = new Mock<DbSet<EquipmentSubhireStatus>>();
            mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.Provider).Returns(statuses.Provider);
            mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.Expression).Returns(statuses.Expression);
            mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.ElementType).Returns(statuses.ElementType);
            mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.GetEnumerator()).Returns(statuses.GetEnumerator());
            _mockContext.Setup(c => c.EquipmentSubhireStatuses).Returns(mockEquipmentSubhireStatuses.Object);
            // Act
            var result = await _vendorService.GetSubhireStatusesAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("P", result.First().StatusCode);
        }
        [Fact]
        public async Task GetRateTypesAsync_ReturnsRateTypes()
        {
            // Arrange
            var rateTypes = new List<string> { "D", "W", "M" }.AsQueryable();
            var mockEquipmentSubhires = new Mock<DbSet<EquipmentSubhire>>();
            mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.Provider).Returns(rateTypes.Provider);
            mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.Expression).Returns(rateTypes.Expression);
            mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.ElementType).Returns(rateTypes.ElementType);
            mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.GetEnumerator()).Returns(rateTypes.GetEnumerator());
            _mockContext.Setup(c => c.EquipmentSubhires).Returns(mockEquipmentSubhires.Object);
            // Act
            var result = await _vendorService.GetRateTypesAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Contains(result, rt => rt.Code == "D");
            Assert.Contains(result, rt => rt.Code == "W");
            Assert.Contains(result, rt => rt.Code == "M");
        }
    }
}