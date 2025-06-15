using System.ComponentModel.DataAnnotations.Schema;

namespace ClairTourTiny.Infrastructure.Dto.FileStorage
{
    public class UserFolderDto
    {
        [Column("entityno")]
        public string? EntityNo { get; set; } = string.Empty;

        [Column("UserFolderPath")]
        public string? UserFolderPath { get; set; } = string.Empty;

        [Column("dropboxFolderID")]
        public string? DropboxFolderId { get; set; }

        [Column("CloudFolderTemplate")]
        public string? CloudFolderTemplate { get; set; } = string.Empty;

        [Column("AttachmentType")]
        public string? AttachmentType { get; set; } = string.Empty;

        [Column("id_Level")]
        public int? IdLevel { get; set; }

        [Column("DropboxFilePathSuffix")]
        public string? DropboxFilePathSuffix { get; set; }
    }
} 