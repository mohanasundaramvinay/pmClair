using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.FileExplorer;
using ClairTourTiny.Infrastructure.Models.FileExplorer;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace ClairTourTiny.Core.Tests
{
    public class FileExplorerServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<ILogger<FileExplorerService>> _mockLogger;
        private readonly Mock<IDbConnection> _mockDbConnection;
        private readonly FileExplorerService _service;
        public FileExplorerServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<ILogger<FileExplorerService>>();
            _mockDbConnection = new Mock<IDbConnection>();
            _mockConfiguration.Setup(c => c.GetConnectionString("DefaultConnection")).Returns("FakeConnectionString");
            _service = new FileExplorerService(_mockConfiguration.Object, _mockLogger.Object);
        }
        [Fact]
        public async Task GetAttachmentCategoryDetailsAsync_ReturnsExpectedResult()
        {
            // Arrange
            var expected = new AttachmentCategoryDetails { AttachmentCategory = "TestCategory" };
            _mockDbConnection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<AttachmentCategoryDetails>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expected);
            // Act
            var result = await _service.GetAttachmentCategoryDetailsAsync("TestCategory");
            // Assert
            Assert.Equal(expected.AttachmentCategory, result.AttachmentCategory);
        }
        [Fact]
        public async Task GetFavoritesFolderNameAsync_ReturnsExpectedResult()
        {
            // Arrange
            var expected = "FavoritesFolder";
            _mockDbConnection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<string>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expected);
            // Act
            var result = await _service.GetFavoritesFolderNameAsync();
            // Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task GetAttachmentTypesAsync_ReturnsExpectedResult()
        {
            // Arrange
            var expected = new List<AttachmentTypeDetails> { new AttachmentTypeDetails { AttachmentCategory = "TestCategory" } };
            _mockDbConnection.SetupDapperAsync(c => c.QueryAsync<AttachmentTypeDetails>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expected);
            // Act
            var result = await _service.GetAttachmentTypesAsync("TestCategory");
            // Assert
            Assert.Equal(expected.Count, result.Count);
        }
        [Fact]
        public async Task GetGroupPermissionsAsync_ReturnsExpectedResult()
        {
            // Arrange
            var expected = new List<GroupPermissionDetails> { new GroupPermissionDetails { GroupName = "TestGroup" } };
            _mockDbConnection.SetupDapperAsync(c => c.QueryAsync<GroupPermissionDetails>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expected);
            // Act
            var result = await _service.GetGroupPermissionsAsync("TestCategory");
            // Assert
            Assert.Equal(expected.Count, result.Count);
        }
        [Fact]
        public async Task GetCloudStorageInfoAsync_ReturnsExpectedResult()
        {
            // Arrange
            var expectedDropboxRootDir = "DropboxRootDir";
            var expectedEgnyteUri = "EgnyteUri";
            _mockDbConnection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<string>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expectedDropboxRootDir);
            _mockDbConnection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<string>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(expectedEgnyteUri);
            // Act
            var result = await _service.GetCloudStorageInfoAsync();
            // Assert
            Assert.True(result.IsEnabled);
            Assert.Equal(expectedDropboxRootDir, result.DropboxRootDirectory);
            Assert.Equal(expectedEgnyteUri, result.EgnyteSharingURI);
        }
        // Additional tests for other methods would follow the same pattern...
    }
}