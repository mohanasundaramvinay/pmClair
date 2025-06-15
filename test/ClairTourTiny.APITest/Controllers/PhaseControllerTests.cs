using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace ClairTourTiny.API.Tests.Controllers
{
    public class PhaseControllerTests
    {
        private readonly Mock<IPhaseService> _mockPhaseService;
        private readonly PhaseController _controller;
        public PhaseControllerTests()
        {
            _mockPhaseService = new Mock<IPhaseService>();
            _controller = new PhaseController(_mockPhaseService.Object);
        }
        [Fact]
        public async Task GetFavoriteProjects_ReturnsOkResult_WithListOfProjects()
        {
            // Arrange
            var mockProjects = new List<Project> { new Project(), new Project() };
            _mockPhaseService.Setup(service => service.GetSuffixes()).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.GetFavoriteProjects();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public async Task GetFavoriteProjects_ReturnsInternalServerError_OnException()
        {
            // Arrange
            _mockPhaseService.Setup(service => service.GetSuffixes()).ThrowsAsync(new System.Exception());
            // Act
            var result = await _controller.GetFavoriteProjects();
            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
    }
}