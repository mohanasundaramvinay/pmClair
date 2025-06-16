using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Projects;
using ClairTourTiny.API.Controllers.V2;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ClairTourTiny.Tests.Controllers.V2
{
    [TestClass]
    public class ProjectControllerTests
    {
        private Mock<IProjectService> _mockProjectService;
        private ProjectController _controller;
        [TestInitialize]
        public void Setup()
        {
            _mockProjectService = new Mock<IProjectService>();
            _controller = new ProjectController(_mockProjectService.Object);
        }
        [TestMethod]
        public async Task GetFavoriteProjects_ReturnsOkResult_WithListOfProjects()
        {
            // Arrange
            var mockProjects = new List<Project> { new Project(), new Project() };
            _mockProjectService.Setup(service => service.GetFavouriteProjects()).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.GetFavoriteProjects();
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(mockProjects, okResult.Value);
        }
        [TestMethod]
        public async Task GetRecentProjects_ReturnsOkResult_WithListOfProjects()
        {
            // Arrange
            var mockProjects = new List<Project> { new Project(), new Project() };
            _mockProjectService.Setup(service => service.GetRecentProjects(It.IsAny<int>())).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.GetRecentProjects(2);
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(mockProjects, okResult.Value);
        }
        [TestMethod]
        public async Task SearchProjects_WithValidSearchTerm_ReturnsOkResult_WithListOfProjects()
        {
            // Arrange
            var mockProjects = new List<Project> { new Project(), new Project() };
            _mockProjectService.Setup(service => service.GetProjects(It.IsAny<string>())).ReturnsAsync(mockProjects);
            // Act
            var result = await _controller.SearchProjects("test");
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(mockProjects, okResult.Value);
        }
        [TestMethod]
        public async Task SearchProjects_WithEmptySearchTerm_ReturnsOkResult_WithEmptyList()
        {
            // Act
            var result = await _controller.SearchProjects("");
            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(0, ((List<Project>)okResult.Value).Count);
        }
        [TestMethod]
        public async Task SearchProjects_WithException_ReturnsBadRequest()
        {
            // Arrange
            _mockProjectService.Setup(service => service.GetProjects(It.IsAny<string>())).ThrowsAsync(new System.Exception("Error"));
            // Act
            var result = await _controller.SearchProjects("test");
            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Error", badRequestResult.Value);
        }
    }
}