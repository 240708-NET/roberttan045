using System;

namespace FinanceApp.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public bool IsIncome { get; set; }
    }
}