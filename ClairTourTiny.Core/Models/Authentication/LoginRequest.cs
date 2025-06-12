using System.ComponentModel.DataAnnotations;

namespace ClairTourTiny.Core.Models.Authentication
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Database { get; set; }
    }
} 