using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Projects;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Dto.Projects;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace ClairTourTiny.Tests
{
    [TestClass]
    public class ProjectServiceTests
    {
        private Mock<ClairTourTinyContext> _mockContext;
        private Mock<IMapper> _mockMapper;
        private ProjectService _projectService;
        [TestInitialize]
        public void Setup()
        {
            _mockContext = new Mock<ClairTourTinyContext>();
            _mockMapper = new Mock<IMapper>();
            _projectService = new ProjectService(_mockContext.Object, _mockMapper.Object);
        }
        [TestMethod]
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
            Assert.AreEqual(projects, result);
        }
        [TestMethod]
        public async Task GetProjects_ReturnsMappedProjects()
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
            Assert.AreEqual(projects, result);
        }
        [TestMethod]
        public async Task GetRecentProjects_ReturnsMappedProjects()
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
            Assert.AreEqual(projects, result);
        }
    }
}