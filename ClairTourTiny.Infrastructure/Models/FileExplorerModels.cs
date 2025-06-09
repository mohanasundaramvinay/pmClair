namespace ClairTourTiny.Infrastructure.Models.FileExplorer
{
    public class AttachmentCategoryDetails
    {
        public string AttachmentCategory { get; set; }
        public bool AttachmentsCanBeInKnowledgeBase { get; set; }
        public bool CanEditKnowledgeBase { get; set; }
        public string DefaultRootFolderPath { get; set; }
    }

    public class AttachmentTypeDetails
    {
        public string AttachmentCategory { get; set; }
        public string AttachmentTypeDescription { get; set; }
        public string AttachmentType { get; set; }
        public string DatabaseRole { get; set; }
        public bool HasPermissions { get; set; }
        public bool CanHaveExpirationDate { get; set; }
        public string Parent { get; set; }
        public string FullAttachmentTypePath { get; set; }
        public int TreeOrder { get; set; }
    }

    public class GroupPermissionDetails
    {
        public string GroupName { get; set; }
        public string AttachmentType { get; set; }
        public bool AllowFullControl { get; set; }
        public bool AllowModify { get; set; }
        public bool AllowReadAndExecute { get; set; }
        public bool AllowListFolderContents { get; set; }
        public bool AllowRead { get; set; }
        public bool AllowWrite { get; set; }
        public bool AllowSpecialPermissions { get; set; }
        public string GroupPath { get; set; }
    }

    public class CloudStorageInfo
    {
        public bool IsEnabled { get; set; }
        public string DropboxRootDirectory { get; set; }
        public string EgnyteSharingURI { get; set; }
    }

    public class CloudStorageTemplateDetails
    {
        public string AttachmentTypeDescription { get; set; }
        public string AttachmentType { get; set; }
        public string CloudFolderTemplate { get; set; }
        public string DropboxFilePathSuffix { get; set; }
    }

    public class CloudFolderTemplateLevel
    {
        public string CloudFolderTemplate { get; set; }
        public int IdLevel { get; set; }
    }

    public class ContactCategoryCloudMapping
    {
        public int IdContactCategory { get; set; }
        public int IdLevel { get; set; }
        public string ContactCategory { get; set; }
        public string LevelDescription { get; set; }
        public string CloudFolderTemplate { get; set; }
    }

    public class RootAttachmentType
    {
        public string CloudFolderTemplate { get; set; }
        public string DropboxFilePathSuffix { get; set; }
    }

    public class FileIndexDetails
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public DateTime CreationTimeUtc { get; set; }
        public Guid GUID { get; set; }
        public string SubFolderPath { get; set; }
        public string FileNameUnique { get; set; }
        public string EntityNo { get; set; }
        public string PartNo { get; set; }
        public string EmpNo { get; set; }
        public string UniqueNo { get; set; }
        public string CreatedBy { get; set; }
        public string Topic { get; set; }
        public bool IsInKnowledgeBase { get; set; }
        public DateTime? DocumentExpirationDateUTC { get; set; }
    }

    public class CloudFileUploadDetails
    {
        public string FileName { get; set; }
        public string EntityNo { get; set; }
        public bool IsUploaded { get; set; }
        public string DropboxFileID { get; set; }
        public DateTime? UploadTime { get; set; }
        public string AttachmentType { get; set; }
        public string AttachmentCategory { get; set; }
        public string UserFolderPath { get; set; }
        public string PartNo { get; set; }
    }

    public class UserFolderDetails
    {
        public string EntityNo { get; set; }
        public string UserFolderPath { get; set; }
        public string DropboxFolderID { get; set; }
        public string CloudFolderTemplate { get; set; }
        public string AttachmentType { get; set; }
        public int IdLevel { get; set; }
        public string DropboxFilePathSuffix { get; set; }
    }

    public class ProjectShareRequestDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CloudFolderTemplate { get; set; }
        public bool IsRemoveFolderMember { get; set; }
        public bool IsAddFolderMember { get; set; }
    }
} 