using System.ComponentModel.DataAnnotations.Schema;

namespace ClairTourTiny.Infrastructure.Dto.FileStorage
{
    public class AttachmentTypeDto
    {
        [Column("AttachmentType")]
        public string? AttachmentType { get; set; }

        [Column("AttachmentTypeDescription")]
        public string? AttachmentTypeDescription { get; set; }

        [Column("AttachmentCategory")]
        public string? AttachmentCategory { get; set; }
    }
}
