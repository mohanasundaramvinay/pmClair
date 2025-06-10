using System;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Logging;
using ClairTourTiny.Core.Models.FileExplorer;
using ClairTourTiny.Infrastructure.Models.FileExplorer;
using System.Data;
using System.Collections.Generic;

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
        /// Gets the root folder path from fileStoragePaths table based on current GUID
        /// </summary>
        /// <param name="currentGuid">The current GUID to search for</param>
        /// <returns>The file storage path if found, empty string otherwise</returns>
        private async Task<string> GetRootFolderPathAsync(string currentGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(currentGuid))
                {
                    _logger.LogDebug("Current GUID is empty, returning empty path");
                    return string.Empty;
                }

                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = @"
                    SELECT fsp.fileStoragePath
                    FROM dbo.fileStoragePaths AS fsp
                    WHERE fsp.fileStorageGUID = @CurrentGuid";

                var path = await connection.QueryFirstOrDefaultAsync<string>(sql, new { CurrentGuid = currentGuid });
                
                _logger.LogDebug("Retrieved root folder path: {Path} for GUID: {Guid}", path, currentGuid);
                
                return path ?? string.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting root folder path for GUID: {CurrentGuid}", currentGuid);
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the global ops finesse data root directory from sysconfig table
        /// </summary>
        /// <returns>The global ops finesse data root directory value if found, null otherwise</returns>
        private async Task<string> GetGlobalOpsFinesseDataRootDirectoryAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = @"
                    SELECT s.value 
                    FROM sysconfig s 
                    WHERE s.tag = 'GLOBAL_OPS_FINESSE_DATA_ROOT_DIRECTORY'";

                var value = await connection.QueryFirstOrDefaultAsync<string>(sql);
                
                _logger.LogDebug("Retrieved global ops finesse data root directory: {Value}", value);
                
                return value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting global ops finesse data root directory from sysconfig");
                return null;
            }
        }

        /// <summary>
        /// Checks for root folder definition and existence, handles GUID validation and folder creation
        /// </summary>
        /// <param name="currentGuid">The current GUID to validate</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <param name="attachmentCategorySubFolderPath">The subfolder path that may be updated</param>
        /// <param name="selectedNodePath">Optional selected node path for combining with root path</param>
        /// <returns>Tuple containing success status and updated attachment category subfolder path</returns>
        public async Task<(bool Success, string UpdatedAttachmentCategorySubFolderPath)> CheckForRootFolderDefinitionAndExistenceAsync(
            string currentGuid, string attachmentCategory, string attachmentCategorySubFolderPath, 
            string selectedNodePath = null)
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

                    // Get global ops finesse data root directory from database
                    var globalOpsFinesseDataRootDirectory = await GetGlobalOpsFinesseDataRootDirectoryAsync();

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

        /// <summary>
        /// Creates a new folder in a selected folder location with user-provided name
        /// </summary>
        /// <param name="newFolderName">The name for the new folder</param>
        /// <param name="currentGlobalOpsFolder">The current global operations folder path</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <param name="entityNo">The entity number associated with the folder</param>
        /// <param name="selectedNodePath">The path of the selected node (parent folder)</param>
        /// <param name="dropboxEnabled">Whether Dropbox integration is enabled</param>
        /// <param name="isLoadingTree">Whether the tree is currently loading (to prevent operations during loading)</param>
        /// <returns>True if folder was created successfully, false if user cancelled or error occurred</returns>
        public async Task<bool> CreateFolderInSelectedFolderAsync(string newFolderName, string currentGlobalOpsFolder, 
            string attachmentCategory, string entityNo, string selectedNodePath = null, bool dropboxEnabled = false, bool isLoadingTree = false)
        {
            try
            {
                // Check if tree is loading
                if (isLoadingTree)
                {
                    _logger.LogDebug("Tree is currently loading, skipping folder creation");
                    return false;
                }

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
                    currentGlobalOpsFolder,
                    selectedNodePath);

                if (!rootFolderExists)
                {
                    _logger.LogError("Root folder definition or existence check failed for category: {AttachmentCategory}", attachmentCategory);
                    return false;
                }

                // Use the updated path if it was modified
                var finalGlobalOpsFolder = updatedPath ?? currentGlobalOpsFolder;

                // Create the full folder path
                var newFolderPath = Path.Combine(finalGlobalOpsFolder, newFolderName);

                // Check if folder already exists
                if (Directory.Exists(newFolderPath))
                {
                    _logger.LogWarning("Folder already exists at path: {NewFolderPath}", newFolderPath);
                    return false;
                }

                // Create the new folder
                await CreateNewFolderAsync(newFolderPath, entityNo, attachmentCategory, 
                    finalGlobalOpsFolder, dropboxEnabled);

                _logger.LogInformation("Successfully created folder in selected location: {NewFolderName} at path: {NewFolderPath}", 
                    newFolderName, newFolderPath);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating folder in selected folder. Name: {NewFolderName}, GlobalOpsFolder: {CurrentGlobalOpsFolder}", 
                    newFolderName, currentGlobalOpsFolder);
                return false;
            }
        }

        /// <summary>
        /// Creates a part file upload request
        /// </summary>
        /// <param name="nodeFullPath">The full path of the node to upload to</param>
        /// <param name="filePath">The path of the file to upload</param>
        /// <param name="attachmentType">The attachment type (from node tag)</param>
        /// <param name="currentPartNo">The current part number</param>
        /// <param name="currentGlobalOpsFolder">The current global operations folder</param>
        /// <returns>True if the upload request was created successfully, false otherwise</returns>
        public async Task<bool> CreatePartFileUploadRequestAsync(string nodeFullPath, string filePath, 
            string attachmentType, string currentPartNo, string currentGlobalOpsFolder)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nodeFullPath))
                {
                    throw new ArgumentNullException(nameof(nodeFullPath), "Node full path cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(currentPartNo))
                {
                    throw new ArgumentNullException(nameof(currentPartNo), "Current part number cannot be null or empty");
                }

                // Validate attachment type
                var at = string.IsNullOrWhiteSpace(attachmentType) || !IsAttachmentType(attachmentType) ? "" : attachmentType;

                // Ensure the folder exists
                var folderPath = currentGlobalOpsFolder;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    _logger.LogInformation("Created folder for part upload: {FolderPath}", folderPath);
                }

                // Create the upload request in database
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("dbo.create_dropbox_part_file_upload_request", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add("@filename", SqlDbType.VarChar, 255).Value = Path.GetFileName(filePath);
                command.Parameters.Add("@partno", SqlDbType.VarChar, 50).Value = currentPartNo;
                command.Parameters.Add("@attachmentType", SqlDbType.VarChar, 50).Value = at;
                command.Parameters.Add("@UserFolderPath", SqlDbType.VarChar, 255).Value = nodeFullPath;

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Successfully created part file upload request for file: {FileName}, Part: {PartNo}, Path: {NodeFullPath}", 
                    Path.GetFileName(filePath), currentPartNo, nodeFullPath);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating part file upload request for file: {FilePath}, Part: {CurrentPartNo}", 
                    filePath, currentPartNo);
                return false;
            }
        }

        /// <summary>
        /// Creates a project file upload request
        /// </summary>
        /// <param name="nodeFullPath">The full path of the node to upload to</param>
        /// <param name="template">The template for the project</param>
        /// <param name="filePath">The path of the file to upload</param>
        /// <param name="attachmentType">The attachment type (from node tag)</param>
        /// <param name="currentEntityNo">The current entity number</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <param name="currentGlobalOpsFolder">The current global operations folder</param>
        /// <returns>True if the upload request was created successfully, false otherwise</returns>
        public async Task<bool> CreateProjectFileUploadRequestAsync(string nodeFullPath, string template, string filePath, 
            string attachmentType, string currentEntityNo, string attachmentCategory, string currentGlobalOpsFolder)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nodeFullPath))
                {
                    throw new ArgumentNullException(nameof(nodeFullPath), "Node full path cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(template))
                {
                    throw new ArgumentNullException(nameof(template), "Template cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(currentEntityNo))
                {
                    throw new ArgumentNullException(nameof(currentEntityNo), "Current entity number cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(attachmentCategory))
                {
                    throw new ArgumentNullException(nameof(attachmentCategory), "Attachment category cannot be null or empty");
                }

                // Validate attachment type
                var at = string.IsNullOrWhiteSpace(attachmentType) || !IsAttachmentType(attachmentType) ? "" : attachmentType;

                // Ensure the temp folder exists
                var rootFilePath = Path.Combine(currentGlobalOpsFolder, "temp");
                EnsureSubdirectoryExists(rootFilePath, template);

                var folderPath = Path.Combine(currentGlobalOpsFolder);

                // Create the upload request in database
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("dbo.create_dropbox_file_upload_request", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add("@filename", SqlDbType.VarChar, 255).Value = Path.GetFileName(filePath);
                command.Parameters.Add("@entityno", SqlDbType.VarChar, 50).Value = currentEntityNo;
                command.Parameters.Add("@attachmentType", SqlDbType.VarChar, 50).Value = at;
                command.Parameters.Add("@attachmentCategory", SqlDbType.VarChar, 50).Value = attachmentCategory;
                command.Parameters.Add("@UserFolderPath", SqlDbType.VarChar, 255).Value = nodeFullPath;

                await command.ExecuteNonQueryAsync();

                _logger.LogInformation("Successfully created project file upload request for file: {FileName}, Entity: {EntityNo}, Template: {Template}, Path: {NodeFullPath}", 
                    Path.GetFileName(filePath), currentEntityNo, template, nodeFullPath);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating project file upload request for file: {FilePath}, Entity: {CurrentEntityNo}, Template: {Template}", 
                    filePath, currentEntityNo, template);
                return false;
            }
        }

        /// <summary>
        /// Checks if the given value is a valid attachment type (placeholder method - implement based on your business logic)
        /// </summary>
        /// <param name="attachmentType">The attachment type to validate</param>
        /// <returns>True if it's a valid attachment type, false otherwise</returns>
        private bool IsAttachmentType(string attachmentType)
        {
            try
            {
                // This is a placeholder implementation
                // You should implement the actual logic based on your business requirements
                // For now, returning true for non-empty values
                _logger.LogDebug("Checking if attachment type is valid: {AttachmentType}", attachmentType);
                
                // Example implementation - replace with your actual logic
                return !string.IsNullOrWhiteSpace(attachmentType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking attachment type: {AttachmentType}", attachmentType);
                return false;
            }
        }

        /// <summary>
        /// Uploads all project files in a folder and its subfolders
        /// </summary>
        /// <param name="selectedFolderPath">The path of the selected folder</param>
        /// <param name="template">The template for the project</param>
        /// <param name="attachmentCategory">The attachment category</param>
        /// <param name="currentGlobalOpsFolder">The current global operations folder</param>
        /// <param name="currentEntityNo">The current entity number</param>
        /// <param name="currentPartNo">The current part number</param>
        /// <param name="selectedFolderAttachmentType">The attachment type of the selected folder</param>
        /// <returns>True if all files were uploaded successfully, false otherwise</returns>
        public async Task<bool> UploadAllProjectFilesInFolderAsync(string selectedFolderPath, string template, 
            string attachmentCategory, string currentGlobalOpsFolder, string currentEntityNo, string currentPartNo, 
            string selectedFolderAttachmentType)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(selectedFolderPath))
                {
                    throw new ArgumentNullException(nameof(selectedFolderPath), "Selected folder path cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(template))
                {
                    throw new ArgumentNullException(nameof(template), "Template cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(attachmentCategory))
                {
                    throw new ArgumentNullException(nameof(attachmentCategory), "Attachment category cannot be null or empty");
                }

                if (string.IsNullOrWhiteSpace(currentGlobalOpsFolder))
                {
                    throw new ArgumentNullException(nameof(currentGlobalOpsFolder), "Current global operations folder cannot be null or empty");
                }

                // Get all folders to process (children + selected folder)
                var foldersToUpload = await GetChildrenFoldersAsync(selectedFolderPath);
                foldersToUpload.Add(selectedFolderPath);

                _logger.LogInformation("Starting upload for {FolderCount} folders in: {SelectedFolderPath}", 
                    foldersToUpload.Count, selectedFolderPath);

                // Handle Projects attachment category
                if (attachmentCategory == "Projects")
                {
                    // Ensure temp folder exists for projects
                    var rootFilePath = Path.Combine(currentGlobalOpsFolder, "temp");
                    EnsureSubdirectoryExists(rootFilePath, template);
                    _logger.LogDebug("Ensured temp folder exists for projects: {RootFilePath}", rootFilePath);
                }

                // Process each folder
                foreach (var folderPath in foldersToUpload)
                {
                    try
                    {
                        // Skip archive folders
                        if (Path.GetFileName(folderPath).Contains("- Archive"))
                        {
                            _logger.LogDebug("Skipping archive folder: {FolderPath}", folderPath);
                            continue;
                        }

                        // Validate attachment type
                        var at = string.IsNullOrWhiteSpace(selectedFolderAttachmentType) || 
                                !IsAttachmentType(selectedFolderAttachmentType) ? "" : selectedFolderAttachmentType;

                        // Get all files in the folder
                        var files = Directory.GetFiles(currentGlobalOpsFolder);
                        _logger.LogDebug("Found {FileCount} files in folder: {FolderPath}", files.Length, folderPath);

                        // Process each file based on attachment category
                        foreach (var file in files)
                        {
                            try
                            {
                                bool uploadSuccess = false;

                                switch (attachmentCategory)
                                {
                                    case "Projects":
                                        uploadSuccess = await CreateProjectFileUploadRequestAsync(
                                            folderPath, template, file, at, currentEntityNo, attachmentCategory, currentGlobalOpsFolder);
                                        break;

                                    case "Parts":
                                        uploadSuccess = await CreatePartFileUploadRequestAsync(
                                            folderPath, file, at, currentPartNo, currentGlobalOpsFolder);
                                        break;

                                    default:
                                        _logger.LogWarning("Unknown attachment category: {AttachmentCategory}", attachmentCategory);
                                        break;
                                }

                                if (uploadSuccess)
                                {
                                    _logger.LogDebug("Successfully created upload request for file: {FileName} in folder: {FolderPath}", 
                                        Path.GetFileName(file), folderPath);
                                }
                                else
                                {
                                    _logger.LogWarning("Failed to create upload request for file: {FileName} in folder: {FolderPath}", 
                                        Path.GetFileName(file), folderPath);
                                }
                            }
                            catch (Exception fileEx)
                            {
                                _logger.LogError(fileEx, "Error processing file: {File} in folder: {FolderPath}", file, folderPath);
                                // Continue with other files
                            }
                        }
                    }
                    catch (Exception folderEx)
                    {
                        _logger.LogError(folderEx, "Error processing folder: {FolderPath}", folderPath);
                        // Continue with other folders
                    }
                }

                _logger.LogInformation("Completed upload process for folder: {SelectedFolderPath}", selectedFolderPath);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading all project files in folder: {SelectedFolderPath}", selectedFolderPath);
                return false;
            }
        }

        /// <summary>
        /// Gets all child folder paths for a given folder (placeholder method - implement based on your business logic)
        /// </summary>
        /// <param name="parentFolderPath">The parent folder path</param>
        /// <returns>List of child folder paths</returns>
        private async Task<List<string>> GetChildrenFoldersAsync(string parentFolderPath)
        {
            try
            {
                // This is a placeholder implementation
                // You should implement the actual logic based on your business requirements
                // For now, returning an empty list
                _logger.LogDebug("Getting child folders for: {ParentFolderPath}", parentFolderPath);
                
                // Example implementation - replace with your actual logic
                // This could involve database queries or file system operations
                var childFolders = new List<string>();
                
                if (Directory.Exists(parentFolderPath))
                {
                    var subdirectories = Directory.GetDirectories(parentFolderPath, "*", SearchOption.AllDirectories);
                    childFolders.AddRange(subdirectories);
                }
                
                return childFolders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting child folders for: {ParentFolderPath}", parentFolderPath);
                return new List<string>();
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
            string selectedNodePath = null);
        Task<bool> CreateFolderInSelectedFolderAsync(string newFolderName, string currentGlobalOpsFolder, 
            string attachmentCategory, string entityNo, string selectedNodePath = null, bool dropboxEnabled = false, bool isLoadingTree = false);
        Task<bool> CreatePartFileUploadRequestAsync(string nodeFullPath, string filePath, 
            string attachmentType, string currentPartNo, string currentGlobalOpsFolder);
        Task<bool> CreateProjectFileUploadRequestAsync(string nodeFullPath, string template, string filePath, 
            string attachmentType, string currentEntityNo, string attachmentCategory, string currentGlobalOpsFolder);
        Task<bool> UploadAllProjectFilesInFolderAsync(string selectedFolderPath, string template, 
            string attachmentCategory, string currentGlobalOpsFolder, string currentEntityNo, string currentPartNo, 
            string selectedFolderAttachmentType);
    }
} 