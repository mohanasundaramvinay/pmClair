namespace ClairTourTiny.Core.Models.FileStorage
{
    public class FolderModel
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullPath { get; set; } = string.Empty;
        public List<FolderModel> Children { get; set; } = new();
    }
}