using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace ClairTourTiny.API.Tests.Controllers.V2
{
    public class ProjectControllerTests
    {
        private readonly Mock<IProjectService> _mockProjectService;
        private readonly ProjectController _controller;
        public ProjectControllerTests()
        {
            _mockProjectService = new Mock<IProjectService>();
            _controller = new ProjectController(_mockProjectService.Object);
        }
        [Fact]
        public async Task GetFavoriteProjects_ReturnsOkResult_WithListOfProjects()
        {
            // Arrange
            var mockProjects = new List<Project> { new Project(), new Project() };
            _mockProjectService.Setup(service => service.GetFavouriteProjects()).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.GetFavoriteProjects();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public async Task GetRecentProjects_ReturnsOkResult_WithListOfProjects()
        {
            // Arrange
            var mockProjects = new List<Project> { new Project(), new Project() };
            _mockProjectService.Setup(service => service.GetRecentProjects(It.IsAny<int>())).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.GetRecentProjects();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public async Task SearchProjects_WithValidSearchTerm_ReturnsOkResult_WithListOfProjects()
        {
            // Arrange
            var mockProjects = new List<Project> { new Project(), new Project() };
            _mockProjectService.Setup(service => service.GetProjects(It.IsAny<string>())).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.SearchProjects("test");
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public async Task SearchProjects_WithNullOrWhitespaceSearchTerm_ReturnsOkResult_WithEmptyList()
        {
            // Act
            var result = await _controller.SearchProjects(null);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Empty(returnValue);
        }
        [Fact]
        public async Task SearchProjects_WhenExceptionThrown_ReturnsBadRequest()
        {
            // Arrange
            _mockProjectService.Setup(service => service.GetProjects(It.IsAny<string>())).ThrowsAsync(new System.Exception("Error"));
            // Act
            var result = await _controller.SearchProjects("test");
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error", badRequestResult.Value);
        }
    }
}