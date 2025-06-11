using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using ClairTourTiny.Infrastructure.Models;
namespace ClairTourTiny.Tests
{
    public class ProjectDataPointsServiceTests
    {
        private readonly Mock<IProjectDataPointsService> _mockService;
        public ProjectDataPointsServiceTests()
        {
            _mockService = new Mock<IProjectDataPointsService>();
        }
        [Fact]
        public async Task GetAllProjectData_ShouldReturnAllProjectData()
        {
            // Arrange
            var expectedData = new AllProjectData();
            _mockService.Setup(service => service.GetAllProjectData(It.IsAny<string>())).ReturnsAsync(expectedData);
            // Act
            var result = await _mockService.Object.GetAllProjectData();
            // Assert
            Assert.Equal(expectedData, result);
        }
        [Fact]
        public async Task GetUserPermissions_ShouldReturnUserPermissions()
        {
            // Arrange
            var expectedPermissions = new UserPermissions();
            _mockService.Setup(service => service.GetUserPermissions()).ReturnsAsync(expectedPermissions);
            // Act
            var result = await _mockService.Object.GetUserPermissions();
            // Assert
            Assert.Equal(expectedPermissions, result);
        }
        [Fact]
        public async Task GetUserCompanyInfo_ShouldReturnUserCompanyInfo()
        {
            // Arrange
            var expectedInfo = new UserCompanyInfo();
            _mockService.Setup(service => service.GetUserCompanyInfo()).ReturnsAsync(expectedInfo);
            // Act
            var result = await _mockService.Object.GetUserCompanyInfo();
            // Assert
            Assert.Equal(expectedInfo, result);
        }
        [Fact]
        public async Task GetCompanies_ShouldReturnCompanies()
        {
            // Arrange
            var expectedCompanies = new List<CompanyInfo>();
            _mockService.Setup(service => service.GetCompanies()).ReturnsAsync(expectedCompanies);
            // Act
            var result = await _mockService.Object.GetCompanies();
            // Assert
            Assert.Equal(expectedCompanies, result);
        }
        // Additional tests for each method in the interface would follow the same pattern
    }
}