using System.ComponentModel.DataAnnotations.Schema;

namespace ClairTourTiny.Infrastructure.Dto.FileStorage
{
    public class UploadedFileDto
    {
        [Column("fileName")]
        public string? FileName { get; set; }

        [Column("UserFolderPath")]
        public string? UserFolderPath { get; set; }
    }
} 