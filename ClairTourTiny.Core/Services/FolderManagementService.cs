using System;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Logging;
using ClairTourTiny.Core.Models.FileExplorer;
using ClairTourTiny.Infrastructure.Models.FileExplorer;
using System.Data;

namespace ClairTourTiny.Core.Services
{
    /// <summary>
    /// Service for managing folder operations in the cloud storage system
    /// </summary>
    public class FolderManagementService : IFolderManagementService
    {
        private readonly string _connectionString;
        private readonly ILogger<FolderManagementService> _logger;

        public FolderManagementService(string connectionString, ILogger<FolderManagementService> logger)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Checks if the root folder is defined and exists in the system
        /// </summary>
        /// <param name="attachmentCategory">The attachment category to check for</param>
        /// <returns>True if root folder exists and is valid, false otherwise</returns>
        // public async Task<bool> CheckForRootFolderDefinitionAndExistenceAsync(string attachmentCategory)
        // {
        //     try
        //     {
        //         using var connection = new SqlConnection(_connectionString);
        //         await connection.OpenAsync();

        //         var sql = @"
        //             SELECT ac.defaultRootFolderPath
        //             FROM dbo.AttachmentCategory ac
        //             WHERE ac.AttachmentCategory = @AttachmentCategory";

        //         var rootPath = await connection.QueryFirstOrDefaultAsync<string>(sql, new { AttachmentCategory = attachmentCategory });

        //         if (string.IsNullOrEmpty(rootPath))
        //         {
        //             _logger.LogWarning("Root folder path not found for attachment category: {AttachmentCategory}", attachmentCategory);
        //             return false;
        //         }

        //         var rootFolderPath = Path.Combine(rootPath, "temp");
        //         if (!Directory.Exists(rootFolderPath))
        //         {
        //             _logger.LogInformation("Creating root folder at path: {RootFolderPath}", rootFolderPath);
        //             Directory.CreateDirectory(rootFolderPath);
        //         }

        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "Error checking root folder definition and existence for category: {AttachmentCategory}", attachmentCategory);
        //         throw;
        //     }
        // }

        // /// <summary>
        /// Checks if a folder has a corresponding database entry
        /// </summary>
        /// <param name="folderPath">The full path of the folder to check</param>
        /// <param name="entityNo">The entity number associated with the folder</param>
        /// <returns>True if folder has database entry, false otherwise</returns>
        public async Task<bool> CheckIfFolderHasDBEntryAsync(string folderPath, string entityNo)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = @"
                    SELECT COUNT(1)
                    FROM dbo.ProjectsUsersFoldersToCloudStorageFolders
                    WHERE UserFolderPath = @FolderPath
                    AND entityno = @EntityNo";

                var count = await connection.ExecuteScalarAsync<int>(sql, new { FolderPath = folderPath, EntityNo = entityNo });
                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking folder database entry for path: {FolderPath}, entity: {EntityNo}", folderPath, entityNo);
                throw;
            }
        }

        /// <summary>
        /// Gets the cloud folder template for a given folder path
        /// </summary>
        /// <param name="folderPath">The full path of the folder</param>
        /// <param name="attachmentCategory">The attachment category of the folder</param>
        /// <returns>The cloud folder template if found, null otherwise</returns>
        public async Task<string> GetCloudFolderTemplateAsync(string folderPath, string attachmentCategory)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = @"
                    SELECT cfsgtat.CloudFolderTemplate
                    FROM dbo.CloudFileStorageGroupsToAttachmentTypes cfsgtat
                    JOIN dbo.AttachmentCategoryTypes act ON act.AttachmentType = cfsgtat.AttachmentType
                    WHERE act.AttachmentCategory = @AttachmentCategory
                    AND EXISTS (
                        SELECT 1 FROM dbo.CloudFileStoragePermissionFolderTemplate cfspft 
                        WHERE cfspft.CloudFolderTemplate = cfsgtat.CloudFolderTemplate
                    )";

                return await connection.QueryFirstOrDefaultAsync<string>(sql, new { AttachmentCategory = attachmentCategory });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cloud folder template for path: {FolderPath}, category: {AttachmentCategory}", 
                    folderPath, attachmentCategory);
                throw;
            }
        }

        /// <summary>
        /// Ensures that a subdirectory exists in the specified path
        /// </summary>
        /// <param name="rootPath">The root path where the subdirectory should exist</param>
        /// <param name="subdirectoryName">The name of the subdirectory to ensure exists</param>
        /// <returns>The full path of the subdirectory</returns>
        public string EnsureSubdirectoryExists(string rootPath, string subdirectoryName)
        {
            try
            {
                if (string.IsNullOrEmpty(rootPath))
                    throw new ArgumentNullException(nameof(rootPath));

                if (string.IsNullOrEmpty(subdirectoryName))
                    throw new ArgumentNullException(nameof(subdirectoryName));

                var fullPath = Path.Combine(rootPath, subdirectoryName);
                
                if (!Directory.Exists(fullPath))
                {
                    _logger.LogInformation("Creating subdirectory at path: {FullPath}", fullPath);
                    Directory.CreateDirectory(fullPath);
                }

                return fullPath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ensuring subdirectory exists at root: {RootPath}, subdirectory: {SubdirectoryName}", 
                    rootPath, subdirectoryName);
                throw;
            }
        }

        /// <summary>
        /// Gets the root default folder path using a stored procedure
        /// </summary>
        /// <param name="currentGuid">The current GUID to use for the query</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <returns>The root default folder path if found, empty string otherwise</returns>
        public async Task<string> GetRootDefaultFolderPathAsync(string currentGuid, string attachmentCategory)
        {
            try
            {
                if (string.IsNullOrEmpty(currentGuid))
                {
                    _logger.LogWarning("Current GUID is empty, returning empty path");
                    return string.Empty;
                }

                if (!Guid.TryParse(currentGuid, out var guid))
                {
                    _logger.LogWarning("Invalid GUID format: {CurrentGuid}", currentGuid);
                    return string.Empty;
                }

                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("dbo.get_default_file_Storage_path", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                command.Parameters.Add("@AttachmentType", SqlDbType.VarChar, 50).Value = attachmentCategory;
                
                var pathParameter = command.Parameters.Add("@path", SqlDbType.VarChar, 255);
                pathParameter.Direction = ParameterDirection.Output;

                await command.ExecuteNonQueryAsync();

                var path = pathParameter.Value?.ToString() ?? string.Empty;
                
                _logger.LogDebug("Retrieved root default folder path: {Path} for GUID: {Guid}, Category: {Category}", 
                    path, currentGuid, attachmentCategory);

                return path;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting root default folder path for GUID: {CurrentGuid}, Category: {AttachmentCategory}", 
                    currentGuid, attachmentCategory);
                throw;
            }
        }

        /// <summary>
        /// Creates a file storage path entry using a stored procedure
        /// </summary>
        /// <param name="folderPath">The folder path to create entry for</param>
        /// <param name="currentGuid">The current GUID to associate with the entry</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task CreateFileStoragePathEntryAsync(string folderPath, string currentGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(folderPath))
                {
                    throw new ArgumentNullException(nameof(folderPath), "Folder path cannot be null or empty");
                }

                if (string.IsNullOrEmpty(currentGuid))
                {
                    throw new ArgumentNullException(nameof(currentGuid), "Current GUID cannot be null or empty");
                }

                if (!Guid.TryParse(currentGuid, out var guid))
                {
                    throw new ArgumentException($"Invalid GUID format: {currentGuid}", nameof(currentGuid));
                }

                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("dbo.createFileStoragePathEntry", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add("@folderPath", SqlDbType.VarChar, 255).Value = folderPath;
                command.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Successfully created file storage path entry for folder: {FolderPath}, GUID: {Guid}", 
                    folderPath, currentGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating file storage path entry for folder: {FolderPath}, GUID: {CurrentGuid}", 
                    folderPath, currentGuid);
                throw;
            }
        }

        /// <summary>
        /// Creates a new folder and optionally adds it to the database
        /// </summary>
        /// <param name="newFolderPath">The full path of the new folder to create</param>
        /// <param name="entityNo">The entity number associated with the folder</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <param name="parentFolderPath">Optional parent folder path for template determination</param>
        /// <param name="dropboxEnabled">Whether Dropbox integration is enabled</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task CreateNewFolderAsync(string newFolderPath, string entityNo, string attachmentCategory, 
            string parentFolderPath = null, bool dropboxEnabled = false)
        {
            try
            {
                if (string.IsNullOrEmpty(newFolderPath))
                {
                    throw new ArgumentNullException(nameof(newFolderPath), "New folder path cannot be null or empty");
                }

                if (string.IsNullOrEmpty(entityNo))
                {
                    throw new ArgumentNullException(nameof(entityNo), "Entity number cannot be null or empty");
                }

                // Create the physical directory
                Directory.CreateDirectory(newFolderPath);
                _logger.LogInformation("Created physical directory at: {NewFolderPath}", newFolderPath);

                var newFolderName = Path.GetFileName(newFolderPath);
                var template = string.Empty;

                // Determine template based on parent folder and conditions
                if (string.IsNullOrEmpty(parentFolderPath))
                {
                    template = "PRODUCTION";
                }
                else if (dropboxEnabled && attachmentCategory == "Projects")
                {
                    template = await GetCloudFolderTemplateAsync(parentFolderPath, attachmentCategory);
                }

                // If Dropbox is not enabled, skip database operations
                if (!dropboxEnabled)
                {
                    _logger.LogDebug("Dropbox not enabled, skipping database operations for folder: {NewFolderPath}", newFolderPath);
                    return;
                }

                var idLevel = await GetIdLevelFromTemplateTypeAsync(template);

                // Insert into database
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = @"
                    INSERT INTO dbo.ProjectsUsersFoldersToCloudStorageFolders
                    (
                        entityno,
                        UserFolderPath,
                        CloudFolderTemplate,
                        id_Level
                    )
                    VALUES
                    (
                        @EntityNo,
                        @UserFolderPath,
                        @CloudFolderTemplate,
                        @IdLevel
                    )";

                var parameters = new
                {
                    EntityNo = entityNo,
                    UserFolderPath = newFolderPath,
                    CloudFolderTemplate = template,
                    IdLevel = idLevel
                };

                await connection.ExecuteAsync(sql, parameters);

                _logger.LogInformation("Successfully created folder entry in database for: {NewFolderPath}, Entity: {EntityNo}, Template: {Template}", 
                    newFolderPath, entityNo, template);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new folder at path: {NewFolderPath}, Entity: {EntityNo}", 
                    newFolderPath, entityNo);
                throw;
            }
        }

        /// <summary>
        /// Gets the ID level from template type (placeholder method - implement based on your business logic)
        /// </summary>
        /// <param name="template">The template type</param>
        /// <returns>The ID level for the template</returns>
        private async Task<int> GetIdLevelFromTemplateTypeAsync(string template)
        {
            try
            {
                // This is a placeholder implementation
                // You should implement the actual logic based on your business requirements
                // For now, returning a default value
                _logger.LogDebug("Getting ID level for template: {Template}", template);
                
                // Example implementation - replace with your actual logic
                return template switch
                {
                    "PRODUCTION" => 1,
                    _ => 0
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting ID level for template: {Template}", template);
                throw;
            }
        }

        /// <summary>
        /// Creates a new folder with user-provided name and validates root folder existence
        /// </summary>
        /// <param name="newFolderName">The name for the new folder</param>
        /// <param name="attachmentCategorySubFolderPath">The base path where the folder should be created</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <param name="entityNo">The entity number associated with the folder</param>
        /// <param name="dropboxEnabled">Whether Dropbox integration is enabled</param>
        /// <returns>True if folder was created successfully, false if user cancelled or error occurred</returns>
        
        //API
        public async Task<bool> CreateFolderWithUserInputAsync(string newFolderName, string attachmentCategorySubFolderPath, 
            string attachmentCategory, string entityNo, bool dropboxEnabled = false)
        {
            try
            {
                // Validate user input
                if (string.IsNullOrWhiteSpace(newFolderName))
                {
                    _logger.LogWarning("User cancelled folder creation or provided empty folder name");
                    return false;
                }

                // Check for root folder definition and existence
                var (rootFolderExists, updatedPath) = await CheckForRootFolderDefinitionAndExistenceAsync(
                    string.Empty, // currentGuid - using empty string as default
                    attachmentCategory,
                    attachmentCategorySubFolderPath);
                
                if (!rootFolderExists)
                {
                    _logger.LogError("Root folder definition or existence check failed for category: {AttachmentCategory}", attachmentCategory);
                    return false;
                }

                // Use the updated path if it was modified
                var finalPath = updatedPath ?? attachmentCategorySubFolderPath;

                // Create the full folder path
                var newFolderPath = Path.Combine(finalPath, newFolderName);

                // Check if folder already exists
                if (Directory.Exists(newFolderPath))
                {
                    _logger.LogWarning("Folder already exists at path: {NewFolderPath}", newFolderPath);
                    return false;
                }

                // Create the new folder
                await CreateNewFolderAsync(newFolderPath, entityNo, attachmentCategory, 
                    finalPath, dropboxEnabled);

                _logger.LogInformation("Successfully created folder: {NewFolderName} at path: {NewFolderPath}", 
                    newFolderName, newFolderPath);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating folder with user input. Name: {NewFolderName}, Path: {AttachmentCategorySubFolderPath}", 
                    newFolderName, attachmentCategorySubFolderPath);
                return false;
            }
        }

        /// <summary>
        /// Checks for root folder definition and existence, handles GUID validation and folder creation
        /// </summary>
        /// <param name="currentGuid">The current GUID to validate</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <param name="attachmentCategorySubFolderPath">The subfolder path that may be updated</param>
        /// <param name="selectedNodePath">Optional selected node path for combining with root path</param>
        /// <param name="globalOpsFinesseDataRootDirectory">The global operations root directory constant</param>
        /// <returns>Tuple containing success status and updated attachment category subfolder path</returns>
        public async Task<(bool Success, string UpdatedAttachmentCategorySubFolderPath)> CheckForRootFolderDefinitionAndExistenceAsync(
            string currentGuid, string attachmentCategory, string attachmentCategorySubFolderPath, 
            string selectedNodePath = null, string globalOpsFinesseDataRootDirectory = null)
        {
            try
            {
                var updatedPath = attachmentCategorySubFolderPath;

                // Check if GUID is empty, null, or DBNull
                if (string.IsNullOrEmpty(currentGuid) || currentGuid == DBNull.Value.ToString())
                {
                    _logger.LogWarning("No GUID provided for root folder check");
                    
                    // Get root default folder path
                    var rootDefaultFolderPath = await GetRootDefaultFolderPathAsync(currentGuid, attachmentCategory);
                    
                    if (string.IsNullOrEmpty(rootDefaultFolderPath))
                    {
                        _logger.LogError("Could not retrieve root default folder path for category: {AttachmentCategory}", attachmentCategory);
                        return (false, updatedPath);
                    }

                    // Determine current global ops folder based on selected node
                    string currentGlobalOpsFolder;
                    if (string.IsNullOrEmpty(selectedNodePath))
                    {
                        currentGlobalOpsFolder = rootDefaultFolderPath;
                    }
                    else
                    {
                        currentGlobalOpsFolder = Path.Combine(rootDefaultFolderPath, selectedNodePath);
                    }

                    // Update attachment category subfolder path if it matches global ops directory
                    if (!string.IsNullOrEmpty(globalOpsFinesseDataRootDirectory) && 
                        attachmentCategorySubFolderPath == globalOpsFinesseDataRootDirectory)
                    {
                        updatedPath = rootDefaultFolderPath;
                        _logger.LogDebug("Updated attachment category subfolder path to root default folder path: {NewPath}", rootDefaultFolderPath);
                    }
                }

                // Check if directory exists and create if necessary
                if (!Directory.Exists(updatedPath))
                {
                    _logger.LogInformation("Root folder does not exist, creating: {AttachmentCategorySubFolderPath}", updatedPath);
                    
                    // Create the directory
                    Directory.CreateDirectory(updatedPath);
                    
                    // Create file storage paths entry
                    await CreateFileStoragePathEntryAsync(updatedPath, currentGuid);
                    
                    _logger.LogInformation("Successfully created root folder and file storage paths entry: {AttachmentCategorySubFolderPath}", 
                        updatedPath);
                }

                return (true, updatedPath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking for root folder definition and existence. GUID: {CurrentGuid}, Category: {AttachmentCategory}", 
                    currentGuid, attachmentCategory);
                return (false, attachmentCategorySubFolderPath);
            }
        }
    }

    /// <summary>
    /// Interface for folder management operations
    /// </summary>
    public interface IFolderManagementService
    {
        //Task<bool> CheckForRootFolderDefinitionAndExistenceAsync(string attachmentCategory);
        Task<bool> CheckIfFolderHasDBEntryAsync(string folderPath, string entityNo);
        Task<string> GetCloudFolderTemplateAsync(string folderPath, string attachmentCategory);
        string EnsureSubdirectoryExists(string rootPath, string subdirectoryName);
        Task<string> GetRootDefaultFolderPathAsync(string currentGuid, string attachmentCategory);
        Task CreateFileStoragePathEntryAsync(string folderPath, string currentGuid);
        Task CreateNewFolderAsync(string newFolderPath, string entityNo, string attachmentCategory, 
            string parentFolderPath = null, bool dropboxEnabled = false);
        Task<bool> CreateFolderWithUserInputAsync(string newFolderName, string attachmentCategorySubFolderPath, 
            string attachmentCategory, string entityNo, bool dropboxEnabled = false);
        Task<(bool Success, string UpdatedAttachmentCategorySubFolderPath)> CheckForRootFolderDefinitionAndExistenceAsync(
            string currentGuid, string attachmentCategory, string attachmentCategorySubFolderPath, 
            string selectedNodePath = null, string globalOpsFinesseDataRootDirectory = null);
    }
} 