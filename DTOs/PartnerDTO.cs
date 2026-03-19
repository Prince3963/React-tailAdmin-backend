namespace MyDummyAPI.DTOs
{
    public class PartnerDTO
    {
        public int UserId { get; set; }
        public string PartnershipType { get; set; } = string.Empty;
        public decimal SharePercentage { get; set; }
        public bool IsMainPartner { get; set; }
    }
}
