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
        _contextMock.Setup(c => c.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()))
            .Returns(Task.FromResult(0));
        _helper = new ProjectMaintenanceHelper();
    }
    [Fact]
    public async Task ProcessAllBulkSaves_ShouldExecuteSql_ForNonEmptySourceLists()
    {
        // Arrange
        var model = new ProjectSaveModel
        {
            Projects = new List<ProjectModel> { new ProjectModel() },
            Equipment = new List<Equipment> { new Equipment() }
        };
        _mapperMock.Setup(m => m.Map(It.IsAny<IEnumerable<object>>(), It.IsAny<Type>(), It.IsAny<Type>()))
            .Returns((IEnumerable<object> source, Type sourceType, Type destType) => source);
        // Act
        await _helper.ProcessAllBulkSaves(model, _mapperMock.Object, _contextMock.Object);
        // Assert
        _contextMock.Verify(c => c.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()),
            Times.AtLeastOnce);
    }
    [Fact]
    public async Task ProcessAllBulkSaves_ShouldNotExecuteSql_ForEmptySourceLists()
    {
        // Arrange
        var model = new ProjectSaveModel();
        // Act
        await _helper.ProcessAllBulkSaves(model, _mapperMock.Object, _contextMock.Object);
        // Assert
        _contextMock.Verify(c => c.Database.ExecuteSqlRawAsync(It.IsAny<string>(), It.IsAny<object[]>()),
            Times.Never);
    }
}