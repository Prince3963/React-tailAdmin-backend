namespace MyDummyAPI.Models
{
    public class DocType : BaseEntity
    {
        public string? TypeName { get; set; }
        public ICollection<Documents> Documents { get; set; } = new List<Documents>();
    }
}
