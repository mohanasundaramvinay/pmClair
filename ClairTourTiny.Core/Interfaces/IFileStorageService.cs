using ClairTourTiny.Core.Models.FileStorage;

namespace ClairTourTiny.Core.Interfaces
{
    public interface IFileStorageService
    {
        Task<FileStorageResponse> GetFileStorageDetailsAsync(string entityNo);
        Task<FileStorageUserResponse> GetFileStorageUsersAsync(string entityNo, string attachmentType, string folderName);
        Task<FileExplorerResponse> GetFileExplorerContentsAsync(string entityNo, string attachmentType, string fullPath);
        Task<FolderModel> CreateFolderAsync(string entityNo, CreateFolderRequest request);
        Task<FileItem> AddFileAsync(string entityNo, AddFileRequest request);
        Task DeleteItemAsync(string entityNo, string path, bool isFolder);
        Task ShareFolderAsync(string entityNo, string fullPath, string attachmentType, List<ShareRequest> requests);
        Task UnshareFolderAsync(string entityNo, string fullPath, string attachmentType, List<ShareRequest> requests);
        Task<(byte[] FileContents, string ContentType, string FileName)> DownloadFileAsync(string entityNo, string filePath);
        Task UploadItemAsync(string entityNo, List<UploadRequest> requests);
    }
}
