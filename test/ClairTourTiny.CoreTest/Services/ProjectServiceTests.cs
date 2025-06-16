using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Projects;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.Projects;
using Microsoft.Data.SqlClient;
using Moq;
using Xunit;
namespace ClairTourTiny.Core.Services.Tests
{
    public class ProjectServiceTests
    {
        private readonly Mock<ClairTourTinyContext> _mockContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProjectService _projectService;
        public ProjectServiceTests()
        {
            _mockContext = new Mock<ClairTourTinyContext>();
            _mockMapper = new Mock<IMapper>();
            _projectService = new ProjectService(_mockContext.Object, _mockMapper.Object);
        }
        [Fact]
        public async Task GetFavouriteProjects_ReturnsMappedProjects()
        {
            // Arrange
            var projectDtos = new List<ProjectFavouriteDto> { new ProjectFavouriteDto() };
            var projects = new List<Project> { new Project() };
            _mockContext.Setup(c => c.ExecuteStoredProcedureAsync<ProjectFavouriteDto>("get_favorite_projects", It.IsAny<SqlParameter[]>()))
                        .ReturnsAsync(projectDtos);
            _mockMapper.Setup(m => m.Map<List<Project>>(projectDtos)).Returns(projects);
            // Act
            var result = await _projectService.GetFavouriteProjects();
            // Assert
            Assert.Equal(projects, result);
        }
        [Fact]
        public async Task GetProjects_WithSearchText_ReturnsMappedProjects()
        {
            // Arrange
            var searchText = "test";
            var projectDtos = new List<ProjectSearchDto> { new ProjectSearchDto() };
            var projects = new List<Project> { new Project() };
            _mockContext.Setup(c => c.ExecuteStoredProcedureAsync<ProjectSearchDto>("search_for_project", It.IsAny<SqlParameter>()))
                        .ReturnsAsync(projectDtos);
            _mockMapper.Setup(m => m.Map<List<Project>>(projectDtos)).Returns(projects);
            // Act
            var result = await _projectService.GetProjects(searchText);
            // Assert
            Assert.Equal(projects, result);
        }
        [Fact]
        public async Task GetRecentProjects_WithNumberOfProjects_ReturnsMappedProjects()
        {
            // Arrange
            var numOfProjects = 5;
            var projectDtos = new List<ProjectRecentDto> { new ProjectRecentDto() };
            var projects = new List<Project> { new Project() };
            _mockContext.Setup(c => c.ExecuteStoredProcedureAsync<ProjectRecentDto>("get_recent_projects", It.IsAny<SqlParameter>()))
                        .ReturnsAsync(projectDtos);
            _mockMapper.Setup(m => m.Map<List<Project>>(projectDtos)).Returns(projects);
            // Act
            var result = await _projectService.GetRecentProjects(numOfProjects);
            // Assert
            Assert.Equal(projects, result);
        }
    }
}