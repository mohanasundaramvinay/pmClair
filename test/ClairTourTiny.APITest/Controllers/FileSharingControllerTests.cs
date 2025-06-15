using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ClairTourTiny.Core.Services;
using ClairTourTiny.API.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
namespace ClairTourTiny.Tests
{
    public class FileSharingControllerTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IFolderManagementService> _mockFolderManagementService;
        private readonly FileSharingController _controller;
        private readonly string _mockConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        public FileSharingControllerTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockFolderManagementService = new Mock<IFolderManagementService>();
            _mockConfiguration.Setup(config => config.GetConnectionString("DefaultConnection")).Returns(_mockConnectionString);
            _controller = new FileSharingController(_mockConfiguration.Object, _mockFolderManagementService.Object);
        }
        [Fact]
        public async Task ShareSelected_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new FileSharingController.ShareRequestModel
            {
                Email = "test@example.com",
                EntityNo = "123",
                CloudFolderTemplate = "template",
                AttachmentCategory = "category",
                UserFolderPath = "path",
                Note = "note"
            };
            // Act
            var result = await _controller.ShareSelected(request);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task ShareSelected_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new FileSharingController.ShareRequestModel();
            // Act
            var result = await _controller.ShareSelected(request);
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
        [Fact]
        public async Task ShareAll_ValidRequests_ReturnsOk()
        {
            // Arrange
            var requests = new List<FileSharingController.ShareRequestModel>
            {
                new FileSharingController.ShareRequestModel
                {
                    Email = "test1@example.com",
                    EntityNo = "123",
                    CloudFolderTemplate = "template1",
                    AttachmentCategory = "category1",
                    UserFolderPath = "path1",
                    Note = "note1"
                },
                new FileSharingController.ShareRequestModel
                {
                    Email = "test2@example.com",
                    EntityNo = "456",
                    CloudFolderTemplate = "template2",
                    AttachmentCategory = "category2",
                    UserFolderPath = "path2",
                    Note = "note2"
                }
            };
            // Act
            var result = await _controller.ShareAll(requests);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task RemoveSelected_ValidRequest_ReturnsOk()
        {
            // Arrange
            string email = "test@example.com";
            string entityNo = "123";
            string template = "template";
            // Act
            var result = await _controller.RemoveSelected(email, entityNo, template);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task RemoveAll_ValidRequest_ReturnsOk()
        {
            // Arrange
            string entityNo = "123";
            string template = "template";
            // Act
            var result = await _controller.RemoveAll(entityNo, template);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task AddOrUpdateFileIndex_ValidRequest_ReturnsOk()
        {
            // Arrange
            string filePath = "C:\\test.txt";
            string guid = "guid";
            string subFolderPath = "subfolder";
            // Act
            var result = await _controller.AddOrUpdateFileIndex(filePath, guid, subFolderPath);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task DeleteFolderFromIndex_ValidRequest_ReturnsOk()
        {
            // Arrange
            string guid = "guid";
            string subFolderPath = "subfolder";
            // Act
            var result = await _controller.DeleteFolderFromIndex(guid, subFolderPath);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task GetOrCreateProjectFolderGuid_ValidEntityNo_ReturnsOk()
        {
            // Arrange
            string entityNo = "123";
            // Act
            var result = await _controller.GetOrCreateProjectFolderGuid(entityNo);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task CreateFolderWithUserInput_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new FileSharingController.CreateFolderRequestModel
            {
                NewFolderName = "NewFolder",
                AttachmentCategorySubFolderPath = "SubFolderPath",
                AttachmentCategory = "Category",
                EntityNo = "123",
                DropboxEnabled = false
            };
            _mockFolderManagementService.Setup(service => service.CreateFolderWithUserInputAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(true);
            // Act
            var result = await _controller.CreateFolderWithUserInput(request);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task CreateFolderInSelectedFolder_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new FileSharingController.CreateFolderInSelectedFolderRequestModel
            {
                NewFolderName = "NewFolder",
                CurrentGlobalOpsFolder = "GlobalOpsFolder",
                AttachmentCategory = "Category",
                EntityNo = "123",
                SelectedNodePath = "NodePath",
                DropboxEnabled = false,
                IsLoadingTree = false
            };
            _mockFolderManagementService.Setup(service => service.CreateFolderInSelectedFolderAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(true);
            // Act
            var result = await _controller.CreateFolderInSelectedFolder(request);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task UploadAllProjectFilesInFolder_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new FileSharingController.UploadAllProjectFilesRequestModel
            {
                SelectedFolderPath = "SelectedFolderPath",
                Template = "Template",
                AttachmentCategory = "Category",
                CurrentGlobalOpsFolder = "GlobalOpsFolder",
                CurrentEntityNo = "123",
                CurrentPartNo = "PartNo",
                SelectedFolderAttachmentType = "AttachmentType"
            };
            _mockFolderManagementService.Setup(service => service.UploadAllProjectFilesInFolderAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            // Act
            var result = await _controller.UploadAllProjectFilesInFolder(request);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}