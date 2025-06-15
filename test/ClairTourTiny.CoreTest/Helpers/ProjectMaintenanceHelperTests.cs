using AutoMapper;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;
using ClairTourTiny.Infrastructure.Helpers;
using ClairTourTiny.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
public class ProjectMaintenanceHelperTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ClairTourTinyContext> _contextMock;
    private readonly ProjectMaintenanceHelper _helper;
    public ProjectMaintenanceHelperTests()
    {
        _mapperMock = new Mock<IMapper>();
        _contextMock = new Mock<ClairTourTinyContext>();
        _helper = new ProjectMaintenanceHelper();
    }
    [Fact]
    public async Task ProcessAllBulkSaves_ShouldNotExecuteSql_WhenSourceListIsEmpty()
    {
        // Arrange
        var model = new ProjectSaveModel();
        _contextMock.Setup(c => c.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
            .Returns(Task.FromResult(0));
        // Act
        await _helper.ProcessAllBulkSaves(model, _mapperMock.Object, _contextMock.Object);
        // Assert
        _contextMock.Verify(c => c.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()), Times.Never);
    }
    [Fact]
    public async Task ProcessAllBulkSaves_ShouldExecuteSql_WhenSourceListIsNotEmpty()
    {
        // Arrange
        var model = new ProjectSaveModel
        {
            Projects = new List<ProjectModel> { new ProjectModel() }
        };
        var mappedProjects = new List<Pm2Project> { new Pm2Project() };
        _mapperMock.Setup(m => m.Map(It.IsAny<IEnumerable<ProjectModel>>(), typeof(ProjectModel), typeof(List<Pm2Project>)))
            .Returns(mappedProjects);
        _contextMock.Setup(c => c.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
            .Returns(Task.FromResult(1));
        // Act
        await _helper.ProcessAllBulkSaves(model, _mapperMock.Object, _contextMock.Object);
        // Assert
        _contextMock.Verify(c => c.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
    }
    // Additional tests can be added here to cover other scenarios, such as verifying the SQL generated for each entity type.
}