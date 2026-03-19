namespace MyDummyAPI.Models
{
    public class BankAccount : BaseEntity
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountHolderName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "USD";
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<BankTransaction> Transactions { get; set; } = new List<BankTransaction>();
    }
}
