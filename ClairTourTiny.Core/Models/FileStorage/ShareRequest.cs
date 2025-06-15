using System.ComponentModel.DataAnnotations;

namespace ClairTourTiny.Core.Models.FileStorage
{
    public class ShareRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Note { get; set; } = string.Empty;
    }
} 