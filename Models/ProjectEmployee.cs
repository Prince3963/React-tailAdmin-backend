namespace MyDummyAPI.Models
{
    public class ProjectEmployee : BaseEntity
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? UnassignedDate { get; set; }
        public string? Role { get; set; }
        public decimal? HourlyRate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsBench { get; set; } = false;

        // Navigation properties
        public Project Project { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
