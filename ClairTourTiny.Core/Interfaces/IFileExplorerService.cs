using ClairTourTiny.Infrastructure.Models.FileExplorer;
using ClairTourTiny.Core.Models.FileExplorer;

namespace ClairTourTiny.Core.Interfaces
{
    public interface IFileExplorerService
    {
        Task<AttachmentCategoryDetails> GetAttachmentCategoryDetailsAsync(string attachmentCategory);
        Task<string> GetFavoritesFolderNameAsync();
        Task<List<AttachmentTypeDetails>> GetAttachmentTypesAsync(string attachmentCategory);
        Task<List<GroupPermissionDetails>> GetGroupPermissionsAsync(string attachmentCategory);
        Task<CloudStorageInfo> GetCloudStorageInfoAsync();
        Task<List<CloudStorageTemplateDetails>> GetCloudStorageTemplatesAsync(string attachmentCategory);
        Task<List<CloudFolderTemplateLevel>> GetCloudFolderTemplatesAsync();
        Task<List<ContactCategoryCloudMapping>> GetContactCategoryCloudMappingsAsync();
        Task<List<RootAttachmentType>> GetRootAttachmentTypesAsync();
        Task<List<FileIndexDetails>> GetFileIndexAsync(Guid guid);
        Task<List<CloudFileUploadDetails>> GetCloudFileUploadsAsync(string attachmentCategory, string entityNo, string partNo);
        Task<List<UserFolderDetails>> GetUserFoldersAsync(string entityNo);
        Task<List<ProjectShareRequestDetails>> GetProjectShareRequestsAsync(string entityNo);

        /// <summary>
        /// Gets available Dropbox invitees for a specific entity
        /// </summary>
        /// <param name="entityNo">The entity number</param>
        /// <returns>List of available invitees</returns>
        Task<List<DropboxInviteeDetails>> GetDropboxInviteesAsync(string entityNo);
    }
} 