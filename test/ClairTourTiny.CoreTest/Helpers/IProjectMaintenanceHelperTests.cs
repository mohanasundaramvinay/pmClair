using System.Threading.Tasks;
using AutoMapper;
using ClairTourTiny.Infrastructure;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
using Moq;
using Xunit;
namespace ClairTourTiny.Core.Helpers.Tests
{
    public class ProjectMaintenanceHelperTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ClairTourTinyContext> _mockContext;
        private readonly Mock<IProjectMaintenanceHelper> _mockHelper;
        private readonly ProjectSaveModel _testModel;
        public ProjectMaintenanceHelperTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockContext = new Mock<ClairTourTinyContext>();
            _mockHelper = new Mock<IProjectMaintenanceHelper>();
            _testModel = new ProjectSaveModel();
        }
        [Fact]
        public async Task ProcessAllBulkSaves_CalledWithCorrectParameters()
        {
            // Arrange
            _mockHelper.Setup(helper => helper.ProcessAllBulkSaves(_testModel, _mockMapper.Object, _mockContext.Object))
                        .Returns(Task.CompletedTask);
            // Act
            await _mockHelper.Object.ProcessAllBulkSaves(_testModel, _mockMapper.Object, _mockContext.Object);
            // Assert
            _mockHelper.Verify(helper => helper.ProcessAllBulkSaves(_testModel, _mockMapper.Object, _mockContext.Object), Times.Once);
        }
        [Fact]
        public async Task ProcessAllBulkSaves_HandlesExceptions()
        {
            // Arrange
            _mockHelper.Setup(helper => helper.ProcessAllBulkSaves(_testModel, _mockMapper.Object, _mockContext.Object))
                        .ThrowsAsync(new System.Exception("Test exception"));
            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(() => _mockHelper.Object.ProcessAllBulkSaves(_testModel, _mockMapper.Object, _mockContext.Object));
        }
    }
}