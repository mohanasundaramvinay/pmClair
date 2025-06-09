using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using ClairTourTiny.Core.Services;

namespace ClairTourTiny.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileSharingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IFolderManagementService _folderManagementService;

        public FileSharingController(IConfiguration configuration, IFolderManagementService folderManagementService)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _folderManagementService = folderManagementService;
        }

        public class ShareRequestModel
        {
            public string Email { get; set; }
            public string EntityNo { get; set; }
            public string CloudFolderTemplate { get; set; }
            public string AttachmentCategory { get; set; }
            public string UserFolderPath { get; set; }
            public string Note { get; set; }
        }

        public class CreateFolderRequestModel
        {
            /// <summary>
            /// The name for the new folder
            /// </summary>
            public string NewFolderName { get; set; }
            
            /// <summary>
            /// The base path where the folder should be created
            /// </summary>
            public string AttachmentCategorySubFolderPath { get; set; }
            
            /// <summary>
            /// The attachment category
            /// </summary>
            public string AttachmentCategory { get; set; }
            
            /// <summary>
            /// The entity number associated with the folder
            /// </summary>
            public string EntityNo { get; set; }
            
            /// <summary>
            /// Whether Dropbox integration is enabled
            /// </summary>
            public bool DropboxEnabled { get; set; } = false;
        }

        public class CreateFolderResponseModel
        {
            /// <summary>
            /// Indicates whether the folder was created successfully
            /// </summary>
            public bool Success { get; set; }
            
            /// <summary>
            /// Message describing the result of the operation
            /// </summary>
            public string Message { get; set; }
            
            /// <summary>
            /// The full path of the created folder (if successful)
            /// </summary>
            public string FolderPath { get; set; }
        }

        public class MemberModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public class ProjectFolderGuidResponse
        {
            public string Guid { get; set; }
            public string Message { get; set; }
        }

        /// <summary>
        /// Share a folder with a specific member
        /// </summary>
        /// <param name="request">Share request details</param>
        /// <returns>Success status of the share operation</returns>
        [HttpPost("share-selected")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ShareSelected([FromBody] ShareRequestModel request)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var command = new SqlCommand("dbo.create_dropbox_share_request", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@email", request.Email);
                    command.Parameters.AddWithValue("@entityno", request.EntityNo);
                    command.Parameters.AddWithValue("@cloudFolderTemplate", request.CloudFolderTemplate);
                    command.Parameters.AddWithValue("@attachmentCategory", request.AttachmentCategory);
                    command.Parameters.AddWithValue("@UserFolderPath", request.UserFolderPath);
                    command.Parameters.AddWithValue("@note", request.Note);

                    await command.ExecuteNonQueryAsync();

                    // Update project share requests table
                    var updateCommand = new SqlCommand(@"
                        IF EXISTS (SELECT 1 FROM dbo.CloudFileStorageShareRequests 
                                 WHERE Email = @email AND CloudFolderTemplate = @template)
                        BEGIN
                            UPDATE dbo.CloudFileStorageShareRequests 
                            SET isAddFolderMember = 1, isRemoveFolderMember = 0
                            WHERE Email = @email AND CloudFolderTemplate = @template
                        END
                        ELSE
                        BEGIN
                            INSERT INTO dbo.CloudFileStorageShareRequests 
                            (Name, Email, CloudFolderTemplate, isAddFolderMember, isRemoveFolderMember)
                            VALUES (@name, @email, @template, 1, 0)
                        END", connection);

                    updateCommand.Parameters.AddWithValue("@email", request.Email);
                    updateCommand.Parameters.AddWithValue("@template", request.CloudFolderTemplate);
                    updateCommand.Parameters.AddWithValue("@name", request.Email.Split('@')[0]); // Basic name extraction

                    await updateCommand.ExecuteNonQueryAsync();
                }

                return Ok(new { message = "Folder shared successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Share a folder with all available members
        /// </summary>
        /// <param name="request">Share request details with list of members</param>
        /// <returns>Success status of the share operation</returns>
        [HttpPost("share-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ShareAll([FromBody] List<ShareRequestModel> requests)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    foreach (var request in requests)
                    {
                        if (string.IsNullOrEmpty(request.Email)) continue;

                        var command = new SqlCommand("dbo.create_dropbox_share_request", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        command.Parameters.AddWithValue("@email", request.Email);
                        command.Parameters.AddWithValue("@entityno", request.EntityNo);
                        command.Parameters.AddWithValue("@cloudFolderTemplate", request.CloudFolderTemplate);
                        command.Parameters.AddWithValue("@attachmentCategory", request.AttachmentCategory);
                        command.Parameters.AddWithValue("@UserFolderPath", request.UserFolderPath);
                        command.Parameters.AddWithValue("@note", request.Note);

                        await command.ExecuteNonQueryAsync();

                        // Update project share requests table
                        var updateCommand = new SqlCommand(@"
                            IF EXISTS (SELECT 1 FROM dbo.CloudFileStorageShareRequests 
                                     WHERE Email = @email AND CloudFolderTemplate = @template)
                            BEGIN
                                UPDATE dbo.CloudFileStorageShareRequests 
                                SET isAddFolderMember = 1, isRemoveFolderMember = 0
                                WHERE Email = @email AND CloudFolderTemplate = @template
                            END
                            ELSE
                            BEGIN
                                INSERT INTO dbo.CloudFileStorageShareRequests 
                                (Name, Email, CloudFolderTemplate, isAddFolderMember, isRemoveFolderMember)
                                VALUES (@name, @email, @template, 1, 0)
                            END", connection);

                        updateCommand.Parameters.AddWithValue("@email", request.Email);
                        updateCommand.Parameters.AddWithValue("@template", request.CloudFolderTemplate);
                        updateCommand.Parameters.AddWithValue("@name", request.Email.Split('@')[0]);

                        await updateCommand.ExecuteNonQueryAsync();
                    }
                }

                return Ok(new { message = "Folders shared successfully with all members" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Remove access for a specific member
        /// </summary>
        /// <param name="email">Email of the member</param>
        /// <param name="entityNo">Entity number</param>
        /// <param name="template">Cloud folder template</param>
        /// <returns>Success status of the remove operation</returns>
        [HttpPost("remove-selected")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveSelected([FromQuery] string email, [FromQuery] string entityNo, [FromQuery] string template)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var command = new SqlCommand(@"
                        UPDATE dbo.CloudFileStorageShareRequests
                        SET isExecuted = 0, isAddFolderMember = 0, isRemoveFolderMember = 1
                        WHERE email = @email 
                        AND entityno = @entityNo 
                        AND CloudFolderTemplate = @template", connection);

                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@entityNo", entityNo);
                    command.Parameters.AddWithValue("@template", template);

                    await command.ExecuteNonQueryAsync();
                }

                return Ok(new { message = "Access removed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Remove access for all members
        /// </summary>
        /// <param name="entityNo">Entity number</param>
        /// <param name="template">Cloud folder template</param>
        /// <returns>Success status of the remove operation</returns>
        [HttpPost("remove-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveAll([FromQuery] string entityNo, [FromQuery] string template)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var command = new SqlCommand(@"
                        UPDATE dbo.CloudFileStorageShareRequests
                        SET isExecuted = 0, isAddFolderMember = 0, isRemoveFolderMember = 1
                        WHERE entityno = @entityNo 
                        AND CloudFolderTemplate = @template", connection);

                    command.Parameters.AddWithValue("@entityNo", entityNo);
                    command.Parameters.AddWithValue("@template", template);

                    await command.ExecuteNonQueryAsync();
                }

                return Ok(new { message = "Access removed successfully for all members" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Add or update file in the search index
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="guid">Current GUID</param>
        /// <param name="subFolderPath">Subfolder path</param>
        /// <returns>Success status of the indexing operation</returns>
        [HttpPost("index-file")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrUpdateFileIndex([FromQuery] string filePath, [FromQuery] string guid, [FromQuery] string subFolderPath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                var fileSecurity = fileInfo.GetAccessControl();
                var owner = fileSecurity.GetOwner(typeof(SecurityIdentifier))
                    .Translate(typeof(NTAccount))
                    .ToString();

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var command = new SqlCommand("dbo.add_File_to_File_Explorer_Search_Index", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@fileName", Path.GetFileName(filePath));
                    command.Parameters.AddWithValue("@fileExtension", Path.GetExtension(filePath));
                    command.Parameters.AddWithValue("@CreationTime", fileInfo.CreationTimeUtc);
                    command.Parameters.AddWithValue("@GUID", guid);
                    command.Parameters.AddWithValue("@subFolderPath", subFolderPath);
                    command.Parameters.AddWithValue("@CreatedBy", owner);

                    await command.ExecuteNonQueryAsync();
                }

                return Ok(new { message = "File indexed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete folder from search index
        /// </summary>
        /// <param name="guid">Current GUID</param>
        /// <param name="subFolderPath">Subfolder path to delete</param>
        /// <returns>Success status of the delete operation</returns>
        [HttpDelete("index-folder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteFolderFromIndex([FromQuery] string guid, [FromQuery] string subFolderPath)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var command = new SqlCommand(@"
                        DELETE FROM dbo.FileAttachmentIndex
                        WHERE GUID = @guid 
                        AND SubFolderPath = @subFolderPath", connection);

                    command.Parameters.AddWithValue("@guid", guid);
                    command.Parameters.AddWithValue("@subFolderPath", subFolderPath);

                    await command.ExecuteNonQueryAsync();
                }

                return Ok(new { message = "Folder deleted from index successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Gets or creates a project folder GUID for a given entity number
        /// </summary>
        /// <param name="entityNo">The entity number to get or create GUID for</param>
        /// <returns>The GUID for the project folder and operation status</returns>
        /// <response code="200">Returns the GUID for the project folder</response>
        /// <response code="400">If the entity number is empty or invalid</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("project-folder-guid")]
        [ProducesResponseType(typeof(ProjectFolderGuidResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrCreateProjectFolderGuid([FromQuery] string entityNo)
        {
            try
            {
                if (string.IsNullOrEmpty(entityNo))
                    return BadRequest(new ProjectFolderGuidResponse 
                    { 
                        Guid = null, 
                        Message = "Entity number is required" 
                    });

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using var command = new SqlCommand("dbo.getOrCreateProjectGUID", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@entityno", entityNo);

                    using var reader = await command.ExecuteReaderAsync();
                    if (!await reader.ReadAsync())
                        return Ok(new ProjectFolderGuidResponse 
                        { 
                            Guid = null, 
                            Message = "No GUID could be created for the given entity number" 
                        });

                    var guid = reader["GUID"].ToString();
                    return Ok(new ProjectFolderGuidResponse 
                    { 
                        Guid = guid, 
                        Message = "GUID retrieved successfully" 
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ProjectFolderGuidResponse 
                { 
                    Guid = null, 
                    Message = $"An error occurred while getting or creating project folder GUID: {ex.Message}" 
                });
            }
        }

        /// <summary>
        /// Creates a new folder with user-provided name and validates root folder existence
        /// </summary>
        /// <param name="request">Folder creation request details</param>
        /// <returns>Success status and details of the folder creation operation</returns>
        /// <response code="200">Returns the result of the folder creation operation</response>
        /// <response code="400">If the request parameters are invalid</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost("create-folder")]
        [ProducesResponseType(typeof(CreateFolderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFolderWithUserInput([FromBody] CreateFolderRequestModel request)
        {
            try
            {
                // Validate request
                if (request == null)
                {
                    return BadRequest(new CreateFolderResponseModel
                    {
                        Success = false,
                        Message = "Request body is required"
                    });
                }

                if (string.IsNullOrWhiteSpace(request.NewFolderName))
                {
                    return BadRequest(new CreateFolderResponseModel
                    {
                        Success = false,
                        Message = "Folder name is required"
                    });
                }

                if (string.IsNullOrWhiteSpace(request.AttachmentCategorySubFolderPath))
                {
                    return BadRequest(new CreateFolderResponseModel
                    {
                        Success = false,
                        Message = "Attachment category subfolder path is required"
                    });
                }

                if (string.IsNullOrWhiteSpace(request.AttachmentCategory))
                {
                    return BadRequest(new CreateFolderResponseModel
                    {
                        Success = false,
                        Message = "Attachment category is required"
                    });
                }

                if (string.IsNullOrWhiteSpace(request.EntityNo))
                {
                    return BadRequest(new CreateFolderResponseModel
                    {
                        Success = false,
                        Message = "Entity number is required"
                    });
                }

                // Call the service method
                var success = await _folderManagementService.CreateFolderWithUserInputAsync(
                    request.NewFolderName,
                    request.AttachmentCategorySubFolderPath,
                    request.AttachmentCategory,
                    request.EntityNo,
                    request.DropboxEnabled);

                if (success)
                {
                    var folderPath = Path.Combine(request.AttachmentCategorySubFolderPath, request.NewFolderName);
                    return Ok(new CreateFolderResponseModel
                    {
                        Success = true,
                        Message = "Folder created successfully",
                        FolderPath = folderPath
                    });
                }
                else
                {
                    return BadRequest(new CreateFolderResponseModel
                    {
                        Success = false,
                        Message = "Failed to create folder. Please check the logs for more details."
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CreateFolderResponseModel
                {
                    Success = false,
                    Message = $"An error occurred while creating the folder: {ex.Message}"
                });
            }
        }
    }
} 