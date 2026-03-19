namespace MyDummyAPI.DTOs
{
    public class ProfileDTO
    {
        public int UserId { get; set; }
        public bool IsPaid { get; set; } = false;
        public int? Amount { get; set; }
    }
}
