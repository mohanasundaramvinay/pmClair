using Microsoft.AspNetCore.Http;

namespace ClairTourTiny.Core.Models.FileStorage
{
    public class AddFileRequest
    {
        public string FileName { get; set; } = string.Empty;
        public string? Path { get; set; }
        public IFormFile File { get; set; } = null!;
    }
} 