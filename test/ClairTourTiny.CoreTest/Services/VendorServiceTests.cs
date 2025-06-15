using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure;
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
        private readonly Mock<DbSet<PartSubhireVendor>> _mockPartSubhireVendors;
        private readonly Mock<DbSet<Povendor>> _mockPovendors;
        private readonly Mock<DbSet<Povendsite>> _mockPovendsites;
        private readonly Mock<DbSet<EquipmentSubhireStatus>> _mockEquipmentSubhireStatuses;
        private readonly Mock<DbSet<EquipmentSubhire>> _mockEquipmentSubhires;
        public VendorServiceTests()
        {
            _mockContext = new Mock<ClairTourTinyContext>();
            _mockLogger = new Mock<ILogger<VendorService>>();
            _mockPartSubhireVendors = new Mock<DbSet<PartSubhireVendor>>();
            _mockPovendors = new Mock<DbSet<Povendor>>();
            _mockPovendsites = new Mock<DbSet<Povendsite>>();
            _mockEquipmentSubhireStatuses = new Mock<DbSet<EquipmentSubhireStatus>>();
            _mockEquipmentSubhires = new Mock<DbSet<EquipmentSubhire>>();
            _mockContext.Setup(m => m.PartSubhireVendors).Returns(_mockPartSubhireVendors.Object);
            _mockContext.Setup(m => m.Povendors).Returns(_mockPovendors.Object);
            _mockContext.Setup(m => m.Povendsites).Returns(_mockPovendsites.Object);
            _mockContext.Setup(m => m.EquipmentSubhireStatuses).Returns(_mockEquipmentSubhireStatuses.Object);
            _mockContext.Setup(m => m.EquipmentSubhires).Returns(_mockEquipmentSubhires.Object);
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
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Provider).Returns(vendors.Provider);
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Expression).Returns(vendors.Expression);
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.ElementType).Returns(vendors.ElementType);
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.GetEnumerator()).Returns(vendors.GetEnumerator());
            _mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.Provider).Returns(povendors.Provider);
            _mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.Expression).Returns(povendors.Expression);
            _mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.ElementType).Returns(povendors.ElementType);
            _mockPovendors.As<IQueryable<Povendor>>().Setup(m => m.GetEnumerator()).Returns(povendors.GetEnumerator());
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Provider).Returns(povendsites.Provider);
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Expression).Returns(povendsites.Expression);
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.ElementType).Returns(povendsites.ElementType);
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.GetEnumerator()).Returns(povendsites.GetEnumerator());
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
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Provider).Returns(povendsites.Provider);
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.Expression).Returns(povendsites.Expression);
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.ElementType).Returns(povendsites.ElementType);
            _mockPovendsites.As<IQueryable<Povendsite>>().Setup(m => m.GetEnumerator()).Returns(povendsites.GetEnumerator());
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
            // Act
            var result = await _vendorService.AddKnownVendorAsync(request);
            // Assert
            Assert.True(result);
            _mockPartSubhireVendors.Verify(m => m.AddAsync(It.IsAny<PartSubhireVendor>(), default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }
        [Fact]
        public async Task IsKnownVendorAsync_ReturnsTrueIfExists()
        {
            // Arrange
            var partNo = "123";
            var vendNo = "V1";
            var siteNo = "S1";
            var vendors = new List<PartSubhireVendor>
            {
                new PartSubhireVendor { Partno = partNo, Vendno = vendNo, Siteno = siteNo }
            }.AsQueryable();
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Provider).Returns(vendors.Provider);
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.Expression).Returns(vendors.Expression);
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.ElementType).Returns(vendors.ElementType);
            _mockPartSubhireVendors.As<IQueryable<PartSubhireVendor>>().Setup(m => m.GetEnumerator()).Returns(vendors.GetEnumerator());
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
                new EquipmentSubhireStatus { StatusCode = "A", SortOrder = 1 }
            }.AsQueryable();
            _mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.Provider).Returns(statuses.Provider);
            _mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.Expression).Returns(statuses.Expression);
            _mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.ElementType).Returns(statuses.ElementType);
            _mockEquipmentSubhireStatuses.As<IQueryable<EquipmentSubhireStatus>>().Setup(m => m.GetEnumerator()).Returns(statuses.GetEnumerator());
            // Act
            var result = await _vendorService.GetSubhireStatusesAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("A", result.First().StatusCode);
        }
        [Fact]
        public async Task GetRateTypesAsync_ReturnsRateTypes()
        {
            // Arrange
            var rateTypes = new List<EquipmentSubhire>
            {
                new EquipmentSubhire { RateType = "D" }
            }.AsQueryable();
            _mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.Provider).Returns(rateTypes.Provider);
            _mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.Expression).Returns(rateTypes.Expression);
            _mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.ElementType).Returns(rateTypes.ElementType);
            _mockEquipmentSubhires.As<IQueryable<EquipmentSubhire>>().Setup(m => m.GetEnumerator()).Returns(rateTypes.GetEnumerator());
            // Act
            var result = await _vendorService.GetRateTypesAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, rt => rt.Code == "D");
        }
    }
}