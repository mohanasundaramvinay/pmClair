using System.Collections.Generic;
using System.Threading.Tasks;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace ClairTourTiny.API.Tests.Controllers
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
        public async Task GetNextAvailableProjectNumber_ReturnsOkResult_WithProjectNumber()
        {
            // Arrange
            int expectedProjectNumber = 123;
            _mockService.Setup(service => service.GetNextAvailableProjectNumber())
                .ReturnsAsync(expectedProjectNumber);
            // Act
            var result = await _controller.GetNextAvailableProjectNumber();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedProjectNumber, okResult.Value);
        }
        [Fact]
        public async Task GetEquipments_ReturnsOkResult_WithEquipments()
        {
            // Arrange
            var entityNo = "ENT123";
            var expectedEquipments = new List<ProjectEquipmentModel> { new ProjectEquipmentModel() };
            _mockService.Setup(service => service.GetEquipments(entityNo))
                .ReturnsAsync(expectedEquipments);
            // Act
            var result = await _controller.GetEquipments(entityNo);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedEquipments, okResult.Value);
        }
        [Fact]
        public async Task GetPurchases_ReturnsOkResult_WithPurchases()
        {
            // Arrange
            var entityNo = "ENT123";
            var expectedPurchases = new List<ProjectPurchaseModel> { new ProjectPurchaseModel() };
            _mockService.Setup(service => service.GetPurchases(entityNo))
                .ReturnsAsync(expectedPurchases);
            // Act
            var result = await _controller.GetPurchases(entityNo);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedPurchases, okResult.Value);
        }
        [Fact]
        public async Task SubmitPhases_ReturnsCreatedResult()
        {
            // Arrange
            var entityNo = "ENT123";
            var model = new ProjectSaveModel();
            _mockService.Setup(service => service.SubmitPhases(entityNo, model))
                .Returns(Task.CompletedTask);
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
            var entityNo = "ENT123";
            var model = new ProjectSaveModel();
            _mockService.Setup(service => service.SubmitPhases(entityNo, model))
                .ThrowsAsync(new System.Exception("Error"));
            // Act
            var result = await _controller.SubmitPhases(entityNo, model);
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
        }
        // Additional tests for other endpoints can be added here following the same pattern.
    }
}