using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClairTourTiny.API.Controllers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models;
using ClairTourTiny.Infrastructure.Dto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
namespace ClairTourTiny.Tests.Controllers
{
    public class ProjectDataPointsControllerTests
    {
        private readonly Mock<IProjectDataPointsService> _mockService;
        private readonly ProjectDataPointsController _controller;
        public ProjectDataPointsControllerTests()
        {
            _mockService = new Mock<IProjectDataPointsService>();
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(config => config.GetConnectionString(It.IsAny<string>())).Returns("FakeConnectionString");
            _controller = new ProjectDataPointsController(_mockService.Object, mockConfiguration.Object);
        }
        [Fact]
        public async Task GetAllProjectData_ReturnsOkResult_WithProjectData()
        {
            // Arrange
            var mockData = new AllProjectData();
            _mockService.Setup(service => service.GetAllProjectData(It.IsAny<string>())).ReturnsAsync(mockData);
            // Act
            var result = await _controller.GetAllProjectData();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<AllProjectData>(okResult.Value);
        }
        [Fact]
        public async Task GetAllProjectData_ReturnsInternalServerError_OnException()
        {
            // Arrange
            _mockService.Setup(service => service.GetAllProjectData(It.IsAny<string>())).ThrowsAsync(new Exception());
            // Act
            var result = await _controller.GetAllProjectData();
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task GetUserPermissions_ReturnsOkResult_WithPermissions()
        {
            // Arrange
            var mockPermissions = new UserPermissions();
            _mockService.Setup(service => service.GetUserPermissions()).ReturnsAsync(mockPermissions);
            // Act
            var result = await _controller.GetUserPermissions();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<UserPermissions>(okResult.Value);
        }
        [Fact]
        public async Task GetUserPermissions_ReturnsInternalServerError_OnException()
        {
            // Arrange
            _mockService.Setup(service => service.GetUserPermissions()).ThrowsAsync(new Exception());
            // Act
            var result = await _controller.GetUserPermissions();
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        // Additional tests for other endpoints would follow the same pattern
    }
}