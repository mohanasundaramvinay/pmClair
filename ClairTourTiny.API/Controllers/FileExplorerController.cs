using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Infrastructure.Models.FileExplorer;
using ClairTourTiny.Core.Models.FileExplorer;

namespace ClairTourTiny.API.Controllers
{
    /// <summary>
    /// Controller for managing file explorer operations and permissions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FileExplorerController : ControllerBase
    {
        private readonly IFileExplorerService _fileExplorerService;
        private readonly ILogger<FileExplorerController> _logger;

        public FileExplorerController(
            IFileExplorerService fileExplorerService,
            ILogger<FileExplorerController> logger)
        {
            _fileExplorerService = fileExplorerService;
            _logger = logger;
        }

        /// <summary>
        /// Gets attachment category details including knowledge base permissions
        /// </summary>
        /// <param name="attachmentCategory">The attachment category to get details for</param>
        /// <returns>Attachment category details with permissions</returns>
        /// <response code="200">Returns the attachment category details</response>
        /// <response code="404">If the attachment category is not found</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("attachmentCategory/{attachmentCategory}")]
        [ProducesResponseType(typeof(AttachmentCategoryDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAttachmentCategoryDetails(string attachmentCategory)
        {
            try
            {
                var details = await _fileExplorerService.GetAttachmentCategoryDetailsAsync(attachmentCategory);
                if (details == null)
                    return NotFound();
                return Ok(details);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting attachment category details for {AttachmentCategory}", attachmentCategory);
                return StatusCode(500, "An error occurred while retrieving attachment category details");
            }
        }

        /// <summary>
        /// Gets the favorites folder name from system configuration
        /// </summary>
        /// <returns>The favorites folder name</returns>
        /// <response code="200">Returns the favorites folder name</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("favoritesFolderName")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFavoritesFolderName()
        {
            try
            {
                var folderName = await _fileExplorerService.GetFavoritesFolderNameAsync();
                return Ok(folderName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting favorites folder name");
                return StatusCode(500, "An error occurred while retrieving favorites folder name");
            }
        }

        /// <summary>
        /// Gets attachment types with permissions for a specific category
        /// </summary>
        /// <param name="attachmentCategory">The attachment category to get types for</param>
        /// <returns>List of attachment types with permissions</returns>
        /// <response code="200">Returns the list of attachment types</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("attachmentTypes/{attachmentCategory}")]
        [ProducesResponseType(typeof(List<AttachmentTypeDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAttachmentTypes(string attachmentCategory)
        {
            try
            {
                var types = await _fileExplorerService.GetAttachmentTypesAsync(attachmentCategory);
                return Ok(types);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting attachment types for {AttachmentCategory}", attachmentCategory);
                return StatusCode(500, "An error occurred while retrieving attachment types");
            }
        }

        /// <summary>
        /// Gets group permissions for a specific attachment category
        /// </summary>
        /// <param name="attachmentCategory">The attachment category to get permissions for</param>
        /// <returns>List of group permissions</returns>
        /// <response code="200">Returns the list of group permissions</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("groupPermissions/{attachmentCategory}")]
        [ProducesResponseType(typeof(List<GroupPermissionDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupPermissions(string attachmentCategory)
        {
            try
            {
                var permissions = await _fileExplorerService.GetGroupPermissionsAsync(attachmentCategory);
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting group permissions for {AttachmentCategory}", attachmentCategory);
                return StatusCode(500, "An error occurred while retrieving group permissions");
            }
        }

        /// <summary>
        /// Gets cloud storage related information if Dropbox is enabled
        /// </summary>
        /// <returns>Cloud storage information</returns>
        /// <response code="200">Returns the cloud storage information</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("cloudStorageInfo")]
        [ProducesResponseType(typeof(CloudStorageInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCloudStorageInfo()
        {
            try
            {
                var info = await _fileExplorerService.GetCloudStorageInfoAsync();
                return Ok(info);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cloud storage info");
                return StatusCode(500, "An error occurred while retrieving cloud storage information");
            }
        }

        /// <summary>
        /// Gets cloud storage attachment type templates for a specific category
        /// </summary>
        /// <param name="attachmentCategory">The attachment category to get templates for</param>
        /// <returns>List of cloud storage templates</returns>
        /// <response code="200">Returns the list of cloud storage templates</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("cloudStorageTemplates/{attachmentCategory}")]
        [ProducesResponseType(typeof(List<CloudStorageTemplateDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCloudStorageTemplates(string attachmentCategory)
        {
            try
            {
                var templates = await _fileExplorerService.GetCloudStorageTemplatesAsync(attachmentCategory);
                return Ok(templates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cloud storage templates for {AttachmentCategory}", attachmentCategory);
                return StatusCode(500, "An error occurred while retrieving cloud storage templates");
            }
        }

        /// <summary>
        /// Gets cloud folder templates with their ID levels
        /// </summary>
        /// <returns>List of cloud folder templates</returns>
        /// <response code="200">Returns the list of cloud folder templates</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("cloudFolderTemplates")]
        [ProducesResponseType(typeof(List<CloudFolderTemplateLevel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCloudFolderTemplates()
        {
            try
            {
                var templates = await _fileExplorerService.GetCloudFolderTemplatesAsync();
                return Ok(templates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cloud folder templates");
                return StatusCode(500, "An error occurred while retrieving cloud folder templates");
            }
        }

        /// <summary>
        /// Gets contact category to cloud storage group mappings
        /// </summary>
        /// <returns>List of contact category cloud mappings</returns>
        /// <response code="200">Returns the list of contact category cloud mappings</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("contactCategoryCloudMappings")]
        [ProducesResponseType(typeof(List<ContactCategoryCloudMapping>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContactCategoryCloudMappings()
        {
            try
            {
                var mappings = await _fileExplorerService.GetContactCategoryCloudMappingsAsync();
                return Ok(mappings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting contact category cloud mappings");
                return StatusCode(500, "An error occurred while retrieving contact category cloud mappings");
            }
        }

        /// <summary>
        /// Gets root attachment types for cloud storage
        /// </summary>
        /// <returns>List of root attachment types</returns>
        /// <response code="200">Returns the list of root attachment types</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("rootAttachmentTypes")]
        [ProducesResponseType(typeof(List<RootAttachmentType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRootAttachmentTypes()
        {
            try
            {
                var types = await _fileExplorerService.GetRootAttachmentTypesAsync();
                return Ok(types);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting root attachment types");
                return StatusCode(500, "An error occurred while retrieving root attachment types");
            }
        }

        /// <summary>
        /// Gets file index details for a specific GUID
        /// </summary>
        /// <param name="guid">The GUID to get file index for</param>
        /// <returns>List of file index details</returns>
        /// <response code="200">Returns the list of file index details</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("fileIndex/{guid}")]
        [ProducesResponseType(typeof(List<FileIndexDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFileIndex(Guid guid)
        {
            try
            {
                var files = await _fileExplorerService.GetFileIndexAsync(guid);
                return Ok(files);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting file index for GUID {Guid}", guid);
                return StatusCode(500, "An error occurred while retrieving file index");
            }
        }

        /// <summary>
        /// Gets cloud file uploads for a specific entity or part
        /// </summary>
        /// <param name="attachmentCategory">The attachment category (Projects or Parts)</param>
        /// <param name="entityNo">The entity number (required for Projects)</param>
        /// <param name="partNo">The part number (required for Parts)</param>
        /// <returns>List of cloud file upload details</returns>
        /// <response code="200">Returns the list of cloud file uploads</response>
        /// <response code="400">If the parameters are invalid</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("cloudFileUploads")]
        [ProducesResponseType(typeof(List<CloudFileUploadDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCloudFileUploads(
            [FromQuery] string attachmentCategory,
            [FromQuery] string entityNo,
            [FromQuery] string partNo)
        {
            try
            {
                if (attachmentCategory != "Projects" && attachmentCategory != "Parts")
                    return BadRequest("Attachment category must be either 'Projects' or 'Parts'");

                if (attachmentCategory == "Projects" && string.IsNullOrEmpty(entityNo))
                    return BadRequest("Entity number is required for Projects");

                if (attachmentCategory == "Parts" && string.IsNullOrEmpty(partNo))
                    return BadRequest("Part number is required for Parts");

                var uploads = await _fileExplorerService.GetCloudFileUploadsAsync(attachmentCategory, entityNo, partNo);
                return Ok(uploads);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cloud file uploads for {Category}, {EntityNo}, {PartNo}", 
                    attachmentCategory, entityNo, partNo);
                return StatusCode(500, "An error occurred while retrieving cloud file uploads");
            }
        }

        /// <summary>
        /// Gets user folders for a specific entity
        /// </summary>
        /// <param name="entityNo">The entity number</param>
        /// <returns>List of user folder details</returns>
        /// <response code="200">Returns the list of user folders</response>
        /// <response code="400">If the entity number is empty</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("userFolders/{entityNo}")]
        [ProducesResponseType(typeof(List<UserFolderDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserFolders(string entityNo)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                    return BadRequest("Entity number is required");

                var folders = await _fileExplorerService.GetUserFoldersAsync(entityNo);
                return Ok(folders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user folders for entity {EntityNo}", entityNo);
                return StatusCode(500, "An error occurred while retrieving user folders");
            }
        }

        /// <summary>
        /// Gets project share requests for a specific entity
        /// </summary>
        /// <param name="entityNo">The entity number</param>
        /// <returns>List of project share request details</returns>
        /// <response code="200">Returns the list of project share requests</response>
        /// <response code="400">If the entity number is empty</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("projectShareRequests/{entityNo}")]
        [ProducesResponseType(typeof(List<ProjectShareRequestDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProjectShareRequests(string entityNo)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                    return BadRequest("Entity number is required");

                var requests = await _fileExplorerService.GetProjectShareRequestsAsync(entityNo);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting project share requests for entity {EntityNo}", entityNo);
                return StatusCode(500, "An error occurred while retrieving project share requests");
            }
        }

        /// <summary>
        /// Gets available Dropbox invitees for a specific entity
        /// </summary>
        /// <param name="entityNo">The entity number</param>
        /// <returns>List of available Dropbox invitees</returns>
        /// <response code="200">Returns the list of available invitees</response>
        /// <response code="400">If the entity number is empty</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("dropboxInvitees/{entityNo}")]
        [ProducesResponseType(typeof(List<DropboxInviteeDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDropboxInvitees(string entityNo)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                    return BadRequest("Entity number is required");

                var invitees = await _fileExplorerService.GetDropboxInviteesAsync(entityNo);
                return Ok(invitees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Dropbox invitees for entity {EntityNo}", entityNo);
                return StatusCode(500, "An error occurred while retrieving Dropbox invitees");
            }
        }
    }
} 