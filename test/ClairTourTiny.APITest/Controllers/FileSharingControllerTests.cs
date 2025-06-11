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
        public FileSharingControllerTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockFolderManagementService = new Mock<IFolderManagementService>();
            _mockConfiguration.Setup(config => config.GetConnectionString(It.IsAny<string>())).Returns("FakeConnectionString");
            _controller = new FileSharingController(_mockConfiguration.Object, _mockFolderManagementService.Object);
        }
        [Fact]
        public async Task ShareSelected_ShouldReturnOk_WhenRequestIsValid()
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
        public async Task ShareSelected_ShouldReturnBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new FileSharingController.ShareRequestModel();
            // Simulate exception
            _mockConfiguration.Setup(config => config.GetConnectionString(It.IsAny<string>())).Throws(new Exception("Database error"));
            // Act
            var result = await _controller.ShareSelected(request);
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
        [Fact]
        public async Task ShareAll_ShouldReturnOk_WhenRequestsAreValid()
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
        public async Task RemoveSelected_ShouldReturnOk_WhenRequestIsValid()
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
        public async Task RemoveAll_ShouldReturnOk_WhenRequestIsValid()
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
        public async Task AddOrUpdateFileIndex_ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            string filePath = "C:\\fakepath\\file.txt";
            string guid = "guid";
            string subFolderPath = "subfolder";
            // Act
            var result = await _controller.AddOrUpdateFileIndex(filePath, guid, subFolderPath);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task DeleteFolderFromIndex_ShouldReturnOk_WhenRequestIsValid()
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
        public async Task GetOrCreateProjectFolderGuid_ShouldReturnOk_WhenEntityNoIsValid()
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
        public async Task CreateFolderWithUserInput_ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var request = new FileSharingController.CreateFolderRequestModel
            {
                NewFolderName = "NewFolder",
                AttachmentCategorySubFolderPath = "C:\\fakepath",
                AttachmentCategory = "category",
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
        public async Task CreateFolderInSelectedFolder_ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var request = new FileSharingController.CreateFolderInSelectedFolderRequestModel
            {
                NewFolderName = "NewFolder",
                CurrentGlobalOpsFolder = "C:\\fakepath",
                AttachmentCategory = "category",
                EntityNo = "123",
                SelectedNodePath = "nodepath",
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
        public async Task UploadAllProjectFilesInFolder_ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var request = new FileSharingController.UploadAllProjectFilesRequestModel
            {
                SelectedFolderPath = "C:\\fakepath",
                Template = "template",
                AttachmentCategory = "category",
                CurrentGlobalOpsFolder = "globalOps",
                CurrentEntityNo = "123",
                CurrentPartNo = "partNo",
                SelectedFolderAttachmentType = "type"
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