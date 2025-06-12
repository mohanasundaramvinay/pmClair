using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ClairTourTiny.API.Tests
{
    public class ProjectMaintenanceControllerTests
    {
        private readonly Mock<IProjectMaintenanceService> _mockService;
        private readonly ProjectMaintenanceController _controller;
        public ProjectMaintenanceControllerTests()
        {
            _mockService = new Mock<IProjectMaintenanceService>();
            _controller = new ProjectMaintenanceController(_mockService.Object);
        }
        [Fact]
        public async Task GetNextAvailableProjectNumber_ReturnsOkResult()
        {
            // Arrange
            _mockService.Setup(service => service.GetNextAvailableProjectNumber()).ReturnsAsync(1);
            // Act
            var result = await _controller.GetNextAvailableProjectNumber();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(1, okResult.Value);
        }
        [Fact]
        public async Task GetEquipments_ReturnsOkResult()
        {
            // Arrange
            var entityNo = "123";
            var equipments = new List<ProjectEquipmentModel>();
            _mockService.Setup(service => service.GetEquipments(entityNo)).ReturnsAsync(equipments);
            // Act
            var result = await _controller.GetEquipments(entityNo);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(equipments, okResult.Value);
        }
        [Fact]
        public async Task GetPurchases_ReturnsOkResult()
        {
            // Arrange
            var entityNo = "123";
            var purchases = new List<ProjectPurchaseModel>();
            _mockService.Setup(service => service.GetPurchases(entityNo)).ReturnsAsync(purchases);
            // Act
            var result = await _controller.GetPurchases(entityNo);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(purchases, okResult.Value);
        }
        [Fact]
        public async Task SubmitPhases_ReturnsCreatedResult()
        {
            // Arrange
            var entityNo = "123";
            var model = new ProjectSaveModel();
            _mockService.Setup(service => service.SubmitPhases(entityNo, model)).Returns(Task.CompletedTask);
            // Act
            var result = await _controller.SubmitPhases(entityNo, model);
            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
        }
        [Fact]
        public async Task SubmitPhases_ReturnsBadRequest_OnException()
        {
            // Arrange
            var entityNo = "123";
            var model = new ProjectSaveModel();
            _mockService.Setup(service => service.SubmitPhases(entityNo, model)).ThrowsAsync(new Exception("Error"));
            // Act
            var result = await _controller.SubmitPhases(entityNo, model);
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Error", badRequestResult.Value);
        }
        // Additional tests for other endpoints can be added here following the same pattern.
    }
}