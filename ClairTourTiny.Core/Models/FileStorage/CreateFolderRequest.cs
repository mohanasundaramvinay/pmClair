namespace ClairTourTiny.Core.Models.FileStorage
{
    public class CreateFolderRequest
    {
        public string FolderName { get; set; } = string.Empty;
        public string ParentPath { get; set; } = string.Empty;
    }
}