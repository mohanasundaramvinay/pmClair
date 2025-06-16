using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace ClairTourTiny.Core.Services.Tests
{
    public class FolderManagementServiceTests
    {
        private readonly Mock<ILogger<FolderManagementService>> _mockLogger;
        private readonly Mock<IDbConnection> _mockDbConnection;
        private readonly FolderManagementService _service;
        public FolderManagementServiceTests()
        {
            _mockLogger = new Mock<ILogger<FolderManagementService>>();
            _mockDbConnection = new Mock<IDbConnection>();
            _service = new FolderManagementService("FakeConnectionString", _mockLogger.Object);
        }
        [Fact]
        public async Task CheckIfFolderHasDBEntryAsync_ShouldReturnTrue_WhenEntryExists()
        {
            // Arrange
            var folderPath = "C:\\TestFolder";
            var entityNo = "123";
            var mockConnection = new Mock<IDbConnection>();
            mockConnection.SetupDapperAsync(c => c.ExecuteScalarAsync<int>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(1);
            // Act
            var result = await _service.CheckIfFolderHasDBEntryAsync(folderPath, entityNo);
            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task CheckIfFolderHasDBEntryAsync_ShouldReturnFalse_WhenNoEntryExists()
        {
            // Arrange
            var folderPath = "C:\\TestFolder";
            var entityNo = "123";
            var mockConnection = new Mock<IDbConnection>();
            mockConnection.SetupDapperAsync(c => c.ExecuteScalarAsync<int>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(0);
            // Act
            var result = await _service.CheckIfFolderHasDBEntryAsync(folderPath, entityNo);
            // Assert
            Assert.False(result);
        }
        [Fact]
        public async Task GetCloudFolderTemplateAsync_ShouldReturnTemplate_WhenTemplateExists()
        {
            // Arrange
            var folderPath = "C:\\TestFolder";
            var attachmentCategory = "TestCategory";
            var expectedTemplate = "Template1";
            var mockConnection = new Mock<IDbConnection>();
            mockConnection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<string>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expectedTemplate);
            // Act
            var result = await _service.GetCloudFolderTemplateAsync(folderPath, attachmentCategory);
            // Assert
            Assert.Equal(expectedTemplate, result);
        }
        [Fact]
        public void EnsureSubdirectoryExists_ShouldCreateDirectory_WhenItDoesNotExist()
        {
            // Arrange
            var rootPath = "C:\\TestRoot";
            var subdirectoryName = "SubDir";
            var fullPath = Path.Combine(rootPath, subdirectoryName);
            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }
            // Act
            var result = _service.EnsureSubdirectoryExists(rootPath, subdirectoryName);
            // Assert
            Assert.True(Directory.Exists(fullPath));
            Assert.Equal(fullPath, result);
        }
        [Fact]
        public async Task GetRootDefaultFolderPathAsync_ShouldReturnPath_WhenGuidIsValid()
        {
            // Arrange
            var currentGuid = Guid.NewGuid().ToString();
            var attachmentCategory = "TestCategory";
            var expectedPath = "C:\\DefaultPath";
            var mockConnection = new Mock<IDbConnection>();
            mockConnection.SetupDapperAsync(c => c.ExecuteScalarAsync<string>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expectedPath);
            // Act
            var result = await _service.GetRootDefaultFolderPathAsync(currentGuid, attachmentCategory);
            // Assert
            Assert.Equal(expectedPath, result);
        }
        [Fact]
        public async Task CreateFileStoragePathEntryAsync_ShouldLogInformation_WhenEntryIsCreated()
        {
            // Arrange
            var folderPath = "C:\\TestFolder";
            var currentGuid = Guid.NewGuid().ToString();
            var mockConnection = new Mock<IDbConnection>();
            mockConnection.SetupDapperAsync(c => c.ExecuteAsync(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(1);
            // Act
            await _service.CreateFileStoragePathEntryAsync(folderPath, currentGuid);
            // Assert
            _mockLogger.Verify(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
        }
        // Additional tests for other methods can be added here following the same pattern
    }
}