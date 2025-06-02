using System.Text.Json.Serialization;

namespace ClairTourTiny.Core.Models.ProjectMaintenance
{
    public class ProjectCrewModel
    {
        public string EntityNo { get; set; } = string.Empty;
        public int SeqNo { get; set; }
        public string JobType { get; set; } = string.Empty;
        public string JobDesc { get; set; } = string.Empty;
        [JsonPropertyName("StartDate")] 
        public DateTime FromDate { get; set; }

        [JsonPropertyName("EndDate")] 
        public DateTime ToDate { get; set; }
        [JsonPropertyName("Quantity")]
        public int CrewSize { get; set; }
        [JsonPropertyName("Hours")]
        public double EstHours { get; set; }
        [JsonPropertyName("HourlyBill")]
        public double EstRate { get; set; }
        public double DailyBill { get; set; }
        public double WeeklyBill { get; set; }
        public int EmpLineNo { get; set; }
        public double AssignedHours
        {
            get
            {
                return AssignedCrew?.Where(ac => ac.StatusCode == "A").Sum(ac => ac.EstHours) ?? 0;
            }
        }

        public int Days
        {
            get
            {
                var daysBetween = (ToDate - FromDate).Days + 1;
                return daysBetween * CrewSize;
            }
        }

        public ICollection<ProjectAssignedCrewModel> AssignedCrew { get; set; } = new HashSet<ProjectAssignedCrewModel>();
    }
}
