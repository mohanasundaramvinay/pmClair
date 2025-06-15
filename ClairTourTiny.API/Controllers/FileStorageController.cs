using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.FileStorage;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClairTourTiny.API.Controllers
{
    [Route("api/entities")]
    [ApiController]
    [Produces("application/json")]
    public class FileStorageController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly ILogger<FileStorageController> _logger;

        public FileStorageController(IFileStorageService fileStorageService,ILogger<FileStorageController> logger)
        {
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        [HttpGet("{entityNo}/directories")]
        [ProducesResponseType(typeof(FileStorageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFileStorageDetails(string entityNo)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    _logger.LogWarning("GetFileStorageDetails called with null or empty entityNo");
                    return BadRequest("EntityNo is required");
                }

                var types = await _fileStorageService.GetFileStorageDetailsAsync(entityNo);
                if (types == null)
                {
                    _logger.LogInformation("No file storage details found for entityNo: {entityNo}", entityNo);
                    return NotFound($"No file storage details found for entityNo: {entityNo}");
                }

                return Ok(types);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting file storage details for {entityNo}", entityNo);
                return StatusCode(500, "An error occurred while retrieving File Storage details");
            }
        }

        [HttpGet("{entityNo}/directories/{attachmentType}/users")]
        [ProducesResponseType(typeof(FileStorageUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFileStorageUsers(string entityNo, string attachmentType, [FromQuery] string fullpath)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    _logger.LogWarning("GetFileStorageUsers called with null or empty entityNo");
                    return BadRequest("EntityNo is required");
                }

                if (string.IsNullOrEmpty(attachmentType))
                {
                    _logger.LogWarning("GetFileStorageUsers called with null or empty attachmentType");
                    return BadRequest("AttachmentType is required");
                }

                var users = await _fileStorageService.GetFileStorageUsersAsync(entityNo, attachmentType, fullpath);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting file storage users for entityNo: {entityNo}, attachmentType: {attachmentType}", 
                    entityNo, attachmentType);
                return StatusCode(500, "An error occurred while retrieving File Storage users");
            }
        }

        [HttpGet("{entityNo}/directories/{attachmentType}/contents")]
        [ProducesResponseType(typeof(FileExplorerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFileExplorerContents(string entityNo, string attachmentType, [FromQuery]string fullPath)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    _logger.LogWarning("GetFileExplorerContents called with null or empty entityNo");
                    return BadRequest("EntityNo is required");
                }

                if (string.IsNullOrEmpty(attachmentType))
                {
                    _logger.LogWarning("GetFileExplorerContents called with null or empty attachmentType");
                    return BadRequest("AttachmentType is required");
                }

                var contents = await _fileStorageService.GetFileExplorerContentsAsync(entityNo, attachmentType, fullPath);
                if (contents == null)
                {
                    _logger.LogInformation("No contents found for entityNo: {entityNo} and attachmentType: {attachmentType}", 
                        entityNo, attachmentType);
                    return NotFound($"No contents found for entityNo: {entityNo} and attachmentType: {attachmentType}");
                }

                return Ok(contents);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting file explorer contents for entityNo: {entityNo}, attachmentType: {attachmentType}", 
                    entityNo, attachmentType);
                return StatusCode(500, "An error occurred while retrieving file explorer contents");
            }
        }

        [HttpPost("{entityNo}/directories")]
        [ProducesResponseType(typeof(FolderModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFolder(string entityNo,[FromBody] CreateFolderRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    _logger.LogWarning("CreateFolder called with null or empty entityNo");
                    return BadRequest("EntityNo is required");
                }
                if (string.IsNullOrEmpty(request.FolderName))
                {
                    _logger.LogWarning("CreateFolder called with null or empty folderName");
                    return BadRequest("FolderName is required");
                }
                var folder = await _fileStorageService.CreateFolderAsync(entityNo, request);
                return Ok(folder);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument in CreateFolder for entityNo: {entityNo}", entityNo);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating folder for entityNo: {entityNo}, folderName: {folderName}", 
                    entityNo, request.FolderName);
                return StatusCode(500, "An error occurred while creating the folder");
            }
        }

        [HttpPost("{entityNo}/files")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FileItem>> AddFile([FromRoute] string entityNo, [FromForm] AddFileRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Request is required");
                }
                var result = await _fileStorageService.AddFileAsync(entityNo, request);
                return Created(HttpContext.Request.Path, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding file for entity {EntityNo}", entityNo);
                return StatusCode(500, "An error occurred while adding the file");
            }
        }

        [HttpDelete("{entityNo}/storages/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteItem([FromRoute] string entityNo, [FromQuery] string path, [FromQuery] bool isFolder)
        {
            try
            {
                await _fileStorageService.DeleteItemAsync(entityNo, path, isFolder);
                return NoContent();
            }
            catch (FileNotFoundException)
            {
                return NotFound("Item not found");
            }
            catch (DirectoryNotFoundException)
            {
                return NotFound("Root folder not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting {ItemType} at path {Path} for entity {EntityNo}", 
                    isFolder ? "folder" : "file", path, entityNo);
                return StatusCode(500, "An error occurred while deleting the item");
            }
        }

        [HttpPost("{entityNo}/storages/share")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ShareFolder([FromRoute] string entityNo, [FromQuery] string fullPath,[FromQuery]string attachmentType, [FromBody] List<ShareRequest> request)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    return BadRequest("EntityNo is required");
                }
                if (string.IsNullOrEmpty(fullPath))
                {
                    return BadRequest("FullPath is required");
                }
                await _fileStorageService.ShareFolderAsync(entityNo, fullPath, attachmentType, request);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DirectoryNotFoundException)
            {
                return NotFound("Root folder not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sharing folder for entity {EntityNo} at path {Path}", entityNo, fullPath);
                return StatusCode(500, "An error occurred while sharing the folder");
            }
        }

        [HttpPost("{entityNo}/storages/unshare")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UnshareFolder([FromRoute] string entityNo, [FromQuery] string fullPath, [FromQuery] string attachmentType, [FromBody] List<ShareRequest> requests)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    return BadRequest("EntityNo is required");
                }

                if (string.IsNullOrEmpty(fullPath))
                {
                    return BadRequest("FullPath is required");
                }

                if (string.IsNullOrEmpty(attachmentType))
                {
                    return BadRequest("AttachmentType is required");
                }

                await _fileStorageService.UnshareFolderAsync(entityNo, fullPath,attachmentType, requests);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error unsharing folder for entity {EntityNo} at path {Path}", entityNo, fullPath);
                return StatusCode(500, "An error occurred while unsharing the folder");
            }
        }

        [HttpGet("{entityNo}/storages/download")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DownloadFile([FromRoute] string entityNo, [FromQuery] string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    return BadRequest("EntityNo is required");
                }

                if (string.IsNullOrEmpty(filePath))
                {
                    return BadRequest("FilePath is required");
                }

                var (fileContents, contentType, fileName) = await _fileStorageService.DownloadFileAsync(entityNo, filePath);
                return File(fileContents, contentType, fileName);
            }
            catch (FileNotFoundException)
            {
                return NotFound("File not found");
            }
            catch (DirectoryNotFoundException)
            {
                return NotFound("Root folder not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error downloading file for entity {EntityNo} at path {Path}", entityNo, filePath);
                return StatusCode(500, "An error occurred while downloading the file");
            }
        }

        [HttpPost("{entityNo}/storages/upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadItem([FromRoute] string entityNo, [FromBody] List<UploadRequest> requests)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                {
                    return BadRequest("EntityNo is required");
                }
                await _fileStorageService.UploadItemAsync(entityNo, requests);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading item for entity {EntityNo}", entityNo);
                return StatusCode(500, "An error occurred while uploading the item");
            }
        }
    }
}
