using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using ClairTourTiny.API.Controllers;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Models.FileExplorer;
using ClairTourTiny.Core.Models.FileExplorer;
public class FileExplorerControllerTests
{
    private readonly Mock<IFileExplorerService> _mockFileExplorerService;
    private readonly Mock<ILogger<FileExplorerController>> _mockLogger;
    private readonly FileExplorerController _controller;
    public FileExplorerControllerTests()
    {
        _mockFileExplorerService = new Mock<IFileExplorerService>();
        _mockLogger = new Mock<ILogger<FileExplorerController>>();
        _controller = new FileExplorerController(_mockFileExplorerService.Object, _mockLogger.Object);
    }
    [Fact]
    public async Task GetAttachmentCategoryDetails_ReturnsOk_WhenDetailsExist()
    {
        // Arrange
        var category = "testCategory";
        var details = new AttachmentCategoryDetails();
        _mockFileExplorerService.Setup(s => s.GetAttachmentCategoryDetailsAsync(category)).ReturnsAsync(details);
        // Act
        var result = await _controller.GetAttachmentCategoryDetails(category);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(details, okResult.Value);
    }
    [Fact]
    public async Task GetAttachmentCategoryDetails_ReturnsNotFound_WhenDetailsDoNotExist()
    {
        // Arrange
        var category = "testCategory";
        _mockFileExplorerService.Setup(s => s.GetAttachmentCategoryDetailsAsync(category)).ReturnsAsync((AttachmentCategoryDetails)null);
        // Act
        var result = await _controller.GetAttachmentCategoryDetails(category);
        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    [Fact]
    public async Task GetAttachmentCategoryDetails_ReturnsServerError_OnException()
    {
        // Arrange
        var category = "testCategory";
        _mockFileExplorerService.Setup(s => s.GetAttachmentCategoryDetailsAsync(category)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetAttachmentCategoryDetails(category);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetFavoritesFolderName_ReturnsOk_WhenFolderNameExists()
    {
        // Arrange
        var folderName = "Favorites";
        _mockFileExplorerService.Setup(s => s.GetFavoritesFolderNameAsync()).ReturnsAsync(folderName);
        // Act
        var result = await _controller.GetFavoritesFolderName();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(folderName, okResult.Value);
    }
    [Fact]
    public async Task GetFavoritesFolderName_ReturnsServerError_OnException()
    {
        // Arrange
        _mockFileExplorerService.Setup(s => s.GetFavoritesFolderNameAsync()).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetFavoritesFolderName();
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetAttachmentTypes_ReturnsOk_WhenTypesExist()
    {
        // Arrange
        var category = "testCategory";
        var types = new List<AttachmentTypeDetails>();
        _mockFileExplorerService.Setup(s => s.GetAttachmentTypesAsync(category)).ReturnsAsync(types);
        // Act
        var result = await _controller.GetAttachmentTypes(category);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(types, okResult.Value);
    }
    [Fact]
    public async Task GetAttachmentTypes_ReturnsServerError_OnException()
    {
        // Arrange
        var category = "testCategory";
        _mockFileExplorerService.Setup(s => s.GetAttachmentTypesAsync(category)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetAttachmentTypes(category);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetGroupPermissions_ReturnsOk_WhenPermissionsExist()
    {
        // Arrange
        var category = "testCategory";
        var permissions = new List<GroupPermissionDetails>();
        _mockFileExplorerService.Setup(s => s.GetGroupPermissionsAsync(category)).ReturnsAsync(permissions);
        // Act
        var result = await _controller.GetGroupPermissions(category);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(permissions, okResult.Value);
    }
    [Fact]
    public async Task GetGroupPermissions_ReturnsServerError_OnException()
    {
        // Arrange
        var category = "testCategory";
        _mockFileExplorerService.Setup(s => s.GetGroupPermissionsAsync(category)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetGroupPermissions(category);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetCloudStorageInfo_ReturnsOk_WhenInfoExists()
    {
        // Arrange
        var info = new CloudStorageInfo();
        _mockFileExplorerService.Setup(s => s.GetCloudStorageInfoAsync()).ReturnsAsync(info);
        // Act
        var result = await _controller.GetCloudStorageInfo();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(info, okResult.Value);
    }
    [Fact]
    public async Task GetCloudStorageInfo_ReturnsServerError_OnException()
    {
        // Arrange
        _mockFileExplorerService.Setup(s => s.GetCloudStorageInfoAsync()).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetCloudStorageInfo();
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetCloudStorageTemplates_ReturnsOk_WhenTemplatesExist()
    {
        // Arrange
        var category = "testCategory";
        var templates = new List<CloudStorageTemplateDetails>();
        _mockFileExplorerService.Setup(s => s.GetCloudStorageTemplatesAsync(category)).ReturnsAsync(templates);
        // Act
        var result = await _controller.GetCloudStorageTemplates(category);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(templates, okResult.Value);
    }
    [Fact]
    public async Task GetCloudStorageTemplates_ReturnsServerError_OnException()
    {
        // Arrange
        var category = "testCategory";
        _mockFileExplorerService.Setup(s => s.GetCloudStorageTemplatesAsync(category)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetCloudStorageTemplates(category);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetCloudFolderTemplates_ReturnsOk_WhenTemplatesExist()
    {
        // Arrange
        var templates = new List<CloudFolderTemplateLevel>();
        _mockFileExplorerService.Setup(s => s.GetCloudFolderTemplatesAsync()).ReturnsAsync(templates);
        // Act
        var result = await _controller.GetCloudFolderTemplates();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(templates, okResult.Value);
    }
    [Fact]
    public async Task GetCloudFolderTemplates_ReturnsServerError_OnException()
    {
        // Arrange
        _mockFileExplorerService.Setup(s => s.GetCloudFolderTemplatesAsync()).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetCloudFolderTemplates();
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetContactCategoryCloudMappings_ReturnsOk_WhenMappingsExist()
    {
        // Arrange
        var mappings = new List<ContactCategoryCloudMapping>();
        _mockFileExplorerService.Setup(s => s.GetContactCategoryCloudMappingsAsync()).ReturnsAsync(mappings);
        // Act
        var result = await _controller.GetContactCategoryCloudMappings();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(mappings, okResult.Value);
    }
    [Fact]
    public async Task GetContactCategoryCloudMappings_ReturnsServerError_OnException()
    {
        // Arrange
        _mockFileExplorerService.Setup(s => s.GetContactCategoryCloudMappingsAsync()).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetContactCategoryCloudMappings();
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetRootAttachmentTypes_ReturnsOk_WhenTypesExist()
    {
        // Arrange
        var types = new List<RootAttachmentType>();
        _mockFileExplorerService.Setup(s => s.GetRootAttachmentTypesAsync()).ReturnsAsync(types);
        // Act
        var result = await _controller.GetRootAttachmentTypes();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(types, okResult.Value);
    }
    [Fact]
    public async Task GetRootAttachmentTypes_ReturnsServerError_OnException()
    {
        // Arrange
        _mockFileExplorerService.Setup(s => s.GetRootAttachmentTypesAsync()).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetRootAttachmentTypes();
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetFileIndex_ReturnsOk_WhenFilesExist()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var files = new List<FileIndexDetails>();
        _mockFileExplorerService.Setup(s => s.GetFileIndexAsync(guid)).ReturnsAsync(files);
        // Act
        var result = await _controller.GetFileIndex(guid);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(files, okResult.Value);
    }
    [Fact]
    public async Task GetFileIndex_ReturnsServerError_OnException()
    {
        // Arrange
        var guid = Guid.NewGuid();
        _mockFileExplorerService.Setup(s => s.GetFileIndexAsync(guid)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetFileIndex(guid);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetCloudFileUploads_ReturnsOk_WhenUploadsExist()
    {
        // Arrange
        var category = "Projects";
        var entityNo = "123";
        var partNo = "";
        var uploads = new List<CloudFileUploadDetails>();
        _mockFileExplorerService.Setup(s => s.GetCloudFileUploadsAsync(category, entityNo, partNo)).ReturnsAsync(uploads);
        // Act
        var result = await _controller.GetCloudFileUploads(category, entityNo, partNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(uploads, okResult.Value);
    }
    [Fact]
    public async Task GetCloudFileUploads_ReturnsBadRequest_WhenInvalidCategory()
    {
        // Arrange
        var category = "InvalidCategory";
        var entityNo = "123";
        var partNo = "";
        // Act
        var result = await _controller.GetCloudFileUploads(category, entityNo, partNo);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
    [Fact]
    public async Task GetCloudFileUploads_ReturnsBadRequest_WhenEntityNoMissingForProjects()
    {
        // Arrange
        var category = "Projects";
        var entityNo = "";
        var partNo = "";
        // Act
        var result = await _controller.GetCloudFileUploads(category, entityNo, partNo);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
    [Fact]
    public async Task GetCloudFileUploads_ReturnsBadRequest_WhenPartNoMissingForParts()
    {
        // Arrange
        var category = "Parts";
        var entityNo = "";
        var partNo = "";
        // Act
        var result = await _controller.GetCloudFileUploads(category, entityNo, partNo);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
    [Fact]
    public async Task GetCloudFileUploads_ReturnsServerError_OnException()
    {
        // Arrange
        var category = "Projects";
        var entityNo = "123";
        var partNo = "";
        _mockFileExplorerService.Setup(s => s.GetCloudFileUploadsAsync(category, entityNo, partNo)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetCloudFileUploads(category, entityNo, partNo);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetUserFolders_ReturnsOk_WhenFoldersExist()
    {
        // Arrange
        var entityNo = "123";
        var folders = new List<UserFolderDetails>();
        _mockFileExplorerService.Setup(s => s.GetUserFoldersAsync(entityNo)).ReturnsAsync(folders);
        // Act
        var result = await _controller.GetUserFolders(entityNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(folders, okResult.Value);
    }
    [Fact]
    public async Task GetUserFolders_ReturnsBadRequest_WhenEntityNoIsEmpty()
    {
        // Arrange
        var entityNo = "";
        // Act
        var result = await _controller.GetUserFolders(entityNo);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
    [Fact]
    public async Task GetUserFolders_ReturnsServerError_OnException()
    {
        // Arrange
        var entityNo = "123";
        _mockFileExplorerService.Setup(s => s.GetUserFoldersAsync(entityNo)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetUserFolders(entityNo);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetProjectShareRequests_ReturnsOk_WhenRequestsExist()
    {
        // Arrange
        var entityNo = "123";
        var requests = new List<ProjectShareRequestDetails>();
        _mockFileExplorerService.Setup(s => s.GetProjectShareRequestsAsync(entityNo)).ReturnsAsync(requests);
        // Act
        var result = await _controller.GetProjectShareRequests(entityNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(requests, okResult.Value);
    }
    [Fact]
    public async Task GetProjectShareRequests_ReturnsBadRequest_WhenEntityNoIsEmpty()
    {
        // Arrange
        var entityNo = "";
        // Act
        var result = await _controller.GetProjectShareRequests(entityNo);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
    [Fact]
    public async Task GetProjectShareRequests_ReturnsServerError_OnException()
    {
        // Arrange
        var entityNo = "123";
        _mockFileExplorerService.Setup(s => s.GetProjectShareRequestsAsync(entityNo)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetProjectShareRequests(entityNo);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
    [Fact]
    public async Task GetDropboxInvitees_ReturnsOk_WhenInviteesExist()
    {
        // Arrange
        var entityNo = "123";
        var invitees = new List<DropboxInviteeDetails>();
        _mockFileExplorerService.Setup(s => s.GetDropboxInviteesAsync(entityNo)).ReturnsAsync(invitees);
        // Act
        var result = await _controller.GetDropboxInvitees(entityNo);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(invitees, okResult.Value);
    }
    [Fact]
    public async Task GetDropboxInvitees_ReturnsBadRequest_WhenEntityNoIsEmpty()
    {
        // Arrange
        var entityNo = "";
        // Act
        var result = await _controller.GetDropboxInvitees(entityNo);
        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
    [Fact]
    public async Task GetDropboxInvitees_ReturnsServerError_OnException()
    {
        // Arrange
        var entityNo = "123";
        _mockFileExplorerService.Setup(s => s.GetDropboxInviteesAsync(entityNo)).ThrowsAsync(new Exception());
        // Act
        var result = await _controller.GetDropboxInvitees(entityNo);
        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
}