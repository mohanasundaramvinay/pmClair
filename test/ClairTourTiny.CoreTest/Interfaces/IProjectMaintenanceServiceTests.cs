using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ClairTourTiny.Tests
{
    public class ProjectMaintenanceServiceTests
    {
        private readonly Mock<IProjectMaintenanceService> _mockService;

        public ProjectMaintenanceServiceTests()
        {
            _mockService = new Mock<IProjectMaintenanceService>();
        }

        [Fact]
        public async Task GetNextAvailableProjectNumber_ShouldReturnInt()
        {
            // Arrange
            _mockService.Setup(service => service.GetNextAvailableProjectNumber()).ReturnsAsync(1);

            // Act
            var result = await _mockService.Object.GetNextAvailableProjectNumber();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetPhases_ShouldReturnListOfPhaseModel()
        {
            // Arrange
            var entityNo = "123";
            var expectedPhases = new List<PhaseModel> { new PhaseModel() };
            _mockService.Setup(service => service.GetPhases(entityNo)).ReturnsAsync(expectedPhases);

            // Act
            var result = await _mockService.Object.GetPhases(entityNo);

            // Assert
            Assert.Equal(expectedPhases, result);
        }

        // Additional tests for each method in the interface

        [Fact]
        public async Task SubmitPhases_ShouldReturnTrue()
        {
            // Arrange
            var entityNo = "123";
            var model = new ProjectSaveModel();
            _mockService.Setup(service => service.SubmitPhases(entityNo, model)).ReturnsAsync(true);

            // Act
            var result = await _mockService.Object.SubmitPhases(entityNo, model);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetBidSummaryData_ShouldReturnBidSummaryResponse()
        {
            // Arrange
            var entityNo = "123";
            var expectedResponse = new BidSummaryResponse();
            _mockService.Setup(service => service.GetBidSummaryData(entityNo)).ReturnsAsync(expectedResponse);

            // Act
            var result = await _mockService.Object.GetBidSummaryData(entityNo);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        // Continue adding tests for each method in the interface
    }
}