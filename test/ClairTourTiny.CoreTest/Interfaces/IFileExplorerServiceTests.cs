using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.FileExplorer;
using ClairTourTiny.Infrastructure.Models.FileExplorer;
namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class FileExplorerServiceTests
    {
        private Mock<IFileExplorerService> _fileExplorerServiceMock;
        [SetUp]
        public void Setup()
        {
            _fileExplorerServiceMock = new Mock<IFileExplorerService>();
        }
        [Test]
        public async Task GetAttachmentCategoryDetailsAsync_ShouldReturnAttachmentCategoryDetails()
        {
            // Arrange
            var expectedDetails = new AttachmentCategoryDetails();
            _fileExplorerServiceMock.Setup(service => service.GetAttachmentCategoryDetailsAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedDetails);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetAttachmentCategoryDetailsAsync("category");
            // Assert
            Assert.AreEqual(expectedDetails, result);
        }
        [Test]
        public async Task GetFavoritesFolderNameAsync_ShouldReturnFolderName()
        {
            // Arrange
            var expectedFolderName = "Favorites";
            _fileExplorerServiceMock.Setup(service => service.GetFavoritesFolderNameAsync())
                .ReturnsAsync(expectedFolderName);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetFavoritesFolderNameAsync();
            // Assert
            Assert.AreEqual(expectedFolderName, result);
        }
        [Test]
        public async Task GetAttachmentTypesAsync_ShouldReturnAttachmentTypes()
        {
            // Arrange
            var expectedTypes = new List<AttachmentTypeDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetAttachmentTypesAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedTypes);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetAttachmentTypesAsync("category");
            // Assert
            Assert.AreEqual(expectedTypes, result);
        }
        [Test]
        public async Task GetGroupPermissionsAsync_ShouldReturnGroupPermissions()
        {
            // Arrange
            var expectedPermissions = new List<GroupPermissionDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetGroupPermissionsAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedPermissions);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetGroupPermissionsAsync("category");
            // Assert
            Assert.AreEqual(expectedPermissions, result);
        }
        [Test]
        public async Task GetCloudStorageInfoAsync_ShouldReturnCloudStorageInfo()
        {
            // Arrange
            var expectedInfo = new CloudStorageInfo();
            _fileExplorerServiceMock.Setup(service => service.GetCloudStorageInfoAsync())
                .ReturnsAsync(expectedInfo);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetCloudStorageInfoAsync();
            // Assert
            Assert.AreEqual(expectedInfo, result);
        }
        [Test]
        public async Task GetCloudStorageTemplatesAsync_ShouldReturnCloudStorageTemplates()
        {
            // Arrange
            var expectedTemplates = new List<CloudStorageTemplateDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetCloudStorageTemplatesAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedTemplates);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetCloudStorageTemplatesAsync("category");
            // Assert
            Assert.AreEqual(expectedTemplates, result);
        }
        [Test]
        public async Task GetCloudFolderTemplatesAsync_ShouldReturnCloudFolderTemplates()
        {
            // Arrange
            var expectedTemplates = new List<CloudFolderTemplateLevel>();
            _fileExplorerServiceMock.Setup(service => service.GetCloudFolderTemplatesAsync())
                .ReturnsAsync(expectedTemplates);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetCloudFolderTemplatesAsync();
            // Assert
            Assert.AreEqual(expectedTemplates, result);
        }
        [Test]
        public async Task GetContactCategoryCloudMappingsAsync_ShouldReturnContactCategoryCloudMappings()
        {
            // Arrange
            var expectedMappings = new List<ContactCategoryCloudMapping>();
            _fileExplorerServiceMock.Setup(service => service.GetContactCategoryCloudMappingsAsync())
                .ReturnsAsync(expectedMappings);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetContactCategoryCloudMappingsAsync();
            // Assert
            Assert.AreEqual(expectedMappings, result);
        }
        [Test]
        public async Task GetRootAttachmentTypesAsync_ShouldReturnRootAttachmentTypes()
        {
            // Arrange
            var expectedTypes = new List<RootAttachmentType>();
            _fileExplorerServiceMock.Setup(service => service.GetRootAttachmentTypesAsync())
                .ReturnsAsync(expectedTypes);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetRootAttachmentTypesAsync();
            // Assert
            Assert.AreEqual(expectedTypes, result);
        }
        [Test]
        public async Task GetFileIndexAsync_ShouldReturnFileIndex()
        {
            // Arrange
            var expectedIndex = new List<FileIndexDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetFileIndexAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedIndex);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetFileIndexAsync(Guid.NewGuid());
            // Assert
            Assert.AreEqual(expectedIndex, result);
        }
        [Test]
        public async Task GetCloudFileUploadsAsync_ShouldReturnCloudFileUploads()
        {
            // Arrange
            var expectedUploads = new List<CloudFileUploadDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetCloudFileUploadsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expectedUploads);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetCloudFileUploadsAsync("category", "entityNo", "partNo");
            // Assert
            Assert.AreEqual(expectedUploads, result);
        }
        [Test]
        public async Task GetUserFoldersAsync_ShouldReturnUserFolders()
        {
            // Arrange
            var expectedFolders = new List<UserFolderDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetUserFoldersAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedFolders);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetUserFoldersAsync("entityNo");
            // Assert
            Assert.AreEqual(expectedFolders, result);
        }
        [Test]
        public async Task GetProjectShareRequestsAsync_ShouldReturnProjectShareRequests()
        {
            // Arrange
            var expectedRequests = new List<ProjectShareRequestDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetProjectShareRequestsAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedRequests);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetProjectShareRequestsAsync("entityNo");
            // Assert
            Assert.AreEqual(expectedRequests, result);
        }
        [Test]
        public async Task GetDropboxInviteesAsync_ShouldReturnDropboxInvitees()
        {
            // Arrange
            var expectedInvitees = new List<DropboxInviteeDetails>();
            _fileExplorerServiceMock.Setup(service => service.GetDropboxInviteesAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedInvitees);
            // Act
            var result = await _fileExplorerServiceMock.Object.GetDropboxInviteesAsync("entityNo");
            // Assert
            Assert.AreEqual(expectedInvitees, result);
        }
    }
}