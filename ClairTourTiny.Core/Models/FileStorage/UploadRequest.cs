using Microsoft.AspNetCore.Http;

namespace ClairTourTiny.Core.Models.FileStorage
{
    public class UploadRequest
    {
        public string? AttachmentType { get; set; }
        public bool IsFile { get; set; } = false;
        public string? Path { get; set; }
    }
} 