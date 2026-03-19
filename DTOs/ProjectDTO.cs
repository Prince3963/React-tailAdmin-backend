using MyDummyAPI.Enums;

namespace MyDummyAPI.DTOs
{
    public class ProjectDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public decimal ProjectValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus Status { get; set; }
        public string PartnerName { get; set; } = string.Empty;
        public int? ProfileId { get; set; }
        public string? TechnologyStack { get; set; }
        public string? ManagerName { get; set; }
        public string? ManagerEmail { get; set; }
        public string? ManagerContact { get; set; }
        public string? LeaveApplyWay { get; set; }
        public string? ClientManagerName { get; set; }
        public string? ClientManagerEmail { get; set; }
        public string? ClientManagerContact { get; set; }
        public bool IsSmooth { get; set; } = false;
        public string? MobileNumberUsed { get; set; }
        public int? InterviewingUserId { get; set; }
        public bool? IsToolUsed { get; set; }
    }
}
