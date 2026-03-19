namespace MyDummyAPI.Models
{
    public class Asset : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Purchase_Date { get; set; }
        public ICollection<MonthlyExpense> MonthlyExpenses { get; set; } = new List<MonthlyExpense>();
    }
}
