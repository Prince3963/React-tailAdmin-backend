namespace MyDummyAPI.Models
{
    public class Profile : BaseEntity
    {
        public int UserId { get; set; }
        public bool IsPaid { get; set; } = false;
        public int? Amount { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}