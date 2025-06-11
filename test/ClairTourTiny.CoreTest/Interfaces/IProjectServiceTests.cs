using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Projects;
namespace ClairTourTiny.Tests
{
    public class ProjectServiceTests
    {
        private readonly Mock<IProjectService> _mockProjectService;
        public ProjectServiceTests()
        {
            _mockProjectService = new Mock<IProjectService>();
        }
        [Fact]
        public async Task GetProjects_ShouldReturnListOfProjects()
        {
            // Arrange
            var searchText = "test";
            var expectedProjects = new List<Project> { new Project() };
            _mockProjectService.Setup(service => service.GetProjects(searchText)).ReturnsAsync(expectedProjects);
            // Act
            var result = await _mockProjectService.Object.GetProjects(searchText);
            // Assert
            Assert.Equal(expectedProjects, result);
            _mockProjectService.Verify(service => service.GetProjects(searchText), Times.Once);
        }
        [Fact]
        public async Task GetRecentProjects_ShouldReturnListOfProjects()
        {
            // Arrange
            int numOfProjects = 5;
            var expectedProjects = new List<Project> { new Project() };
            _mockProjectService.Setup(service => service.GetRecentProjects(numOfProjects)).ReturnsAsync(expectedProjects);
            // Act
            var result = await _mockProjectService.Object.GetRecentProjects(numOfProjects);
            // Assert
            Assert.Equal(expectedProjects, result);
            _mockProjectService.Verify(service => service.GetRecentProjects(numOfProjects), Times.Once);
        }
        [Fact]
        public async Task GetFavouriteProjects_ShouldReturnListOfProjects()
        {
            // Arrange
            var expectedProjects = new List<Project> { new Project() };
            _mockProjectService.Setup(service => service.GetFavouriteProjects()).ReturnsAsync(expectedProjects);
            // Act
            var result = await _mockProjectService.Object.GetFavouriteProjects();
            // Assert
            Assert.Equal(expectedProjects, result);
            _mockProjectService.Verify(service => service.GetFavouriteProjects(), Times.Once);
        }
    }
}