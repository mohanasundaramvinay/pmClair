using System.Text.Json.Serialization;

namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class ProjectClientContactModel
    {
        public string EntityNo { get; set; } = string.Empty;
        [JsonPropertyName("Category")]
        public int IdContactCategory { get; set; }
        public string ContactNo { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        [JsonPropertyName("Name")]
        public string? ContactName { get; set; }
    }
}
