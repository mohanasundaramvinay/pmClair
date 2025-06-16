using System.ComponentModel.DataAnnotations.Schema;

namespace ClairTourTiny.Infrastructure.Dto.FileStorage
{
    public class AttachmentCategoryDto
    {
        [Column("AttachmentCategory")]
        public string? AttachmentCategory { get; set; }

        [Column("attachmentsCanBeInKnowledgeBase")]
        public bool? AttachmentsCanBeInKnowledgeBase { get; set; }

        [Column("CanEditKnowledgeBase")]
        public int? CanEditKnowledgeBase { get; set; }

        [Column("defaultRootFolderPath")]
        public string? DefaultRootFolderPath { get; set; }
    }
} 