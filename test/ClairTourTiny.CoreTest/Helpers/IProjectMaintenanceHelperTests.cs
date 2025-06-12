using System.Threading.Tasks;
using Moq;
using Xunit;
using ClairTourTiny.Core.Helpers;
using ClairTourTiny.Infrastructure.Models.ProjectMaintenance;
namespace ClairTourTiny.Tests.Helpers
{
    public class ProjectMaintenanceHelperTests
    {
        [Fact]
        public async Task ProcessAllBulkSaves_ShouldBeCalled_WithCorrectParameters()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockContext = new Mock<ClairTourTinyContext>();
            var mockHelper = new Mock<IProjectMaintenanceHelper>();
            var model = new ProjectSaveModel();
            
            // Act
            await mockHelper.Object.ProcessAllBulkSaves(model, mockMapper.Object, mockContext.Object);
            
            // Assert
            mockHelper.Verify(helper => helper.ProcessAllBulkSaves(model, mockMapper.Object, mockContext.Object), Times.Once);
        }
    }
}