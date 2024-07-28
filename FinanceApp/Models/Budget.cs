namespace FinanceApp.Models
{
    public class Budget
    {
        public string UserId { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public decimal Spent { get; set; }
    }
}