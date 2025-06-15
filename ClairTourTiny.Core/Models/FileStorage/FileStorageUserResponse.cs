namespace ClairTourTiny.Core.Models.FileStorage
{
    public class FileStorageUserResponse
    {
        public List<UserModel> MappedUsers { get; set; } = new();
        public List<UserModel> AvailableUsers { get; set; } = new();
    }

    public class UserModel
    {
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int? LevelId { get; set; }
    }
} 