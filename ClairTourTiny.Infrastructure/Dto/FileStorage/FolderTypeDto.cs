using System.ComponentModel.DataAnnotations.Schema;

namespace ClairTourTiny.Infrastructure.Dto.FileStorage
{
    public class FolderTypeDto
    {
        [Column("AttachmentCategory")]
        public string AttachmentCategory { get; set; } = string.Empty;

        [Column("AttachmentTypeDescription")]
        public string? AttachmentTypeDescription { get; set; }

        [Column("Permissionsneeded")]
        public int? Permissionsneeded { get; set; }

        [Column("AttachmentType")]
        public string AttachmentType { get; set; } = string.Empty;

        [Column("DatabaseRole")]
        public string? DatabaseRole { get; set; }

        [Column("hasPermissions")]
        public int hasPermissions { get; set; }

        [Column("CanHaveExpirationDate")]
        public bool CanHaveExpirationDate { get; set; }

        [Column("Parent")]
        public string? Parent { get; set; }

        [Column("FullAttachmentTypePath")]
        public string? FullAttachmentTypePath { get; set; }

        [Column("TreeOrder")]
        public double? TreeOrder { get; set; }
    }
}
