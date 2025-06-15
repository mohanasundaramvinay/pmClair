namespace ClairTourTiny.Core.Models.FileStorage
{
    public class FileExplorerResponse
    {
        public List<FileItem> Files { get; set; } = new();
        public List<FolderItem> Folders { get; set; } = new();
    }

    public class FileItem
    {
        public string Name { get; set; } = string.Empty;
        public long Size { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsUploaded { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;
    }

    public class FolderItem
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;
        public DateTime LastModified { get; set; }
        public bool IsUploaded { get; set; }
    }
} 