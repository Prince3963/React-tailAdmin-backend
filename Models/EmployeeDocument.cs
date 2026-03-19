namespace MyDummyAPI.Models
{
    public class EmployeeDocument : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int DocumentId { get; set; }
        public Employee? Employee { get; set; } = null;
        public Documents? Documents { get; set; } = null;
    }
}
