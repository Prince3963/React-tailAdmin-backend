namespace MyDummyAPI.Models
{
    public class Documents : BaseEntity
    {
        public int DocType_Id { get; set; }
        public string? Link { get; set; }
        public DocType? DocType { get; set; }
        public ICollection<EmployeeDocument> EmployeeDocuments { get; set; } = new List<EmployeeDocument>();
    }
}
