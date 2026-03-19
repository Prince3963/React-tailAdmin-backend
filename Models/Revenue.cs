namespace MyDummyAPI.Models
{
    public class Revenue : BaseEntity
    {
        public int PartnerId { get; set; }
        public int? ProjectId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Revenue_From { get; set; } = true;
        public string? Notes { get; set; }
        public Partner? Partner { get; set; }
        public Project? Project { get; set; }
    }
}
