using System.Collections.Generic;
using System.Linq;
using FinanceApp.Models;

namespace FinanceApp.Services
{
    public class BudgetService
    {
        private List<Budget> budgets = new List<Budget>();

        public void SetBudget(string userId, string category, decimal amount)
        {
            var budget = budgets.FirstOrDefault(b => b.UserId == userId && b.Category == category);
            if (budget == null)
            {
                budgets.Add(new Budget { UserId = userId, Category = category, Amount = amount, Spent = 0 });
            }
            else
            {
                budget.Amount = amount;
            }
        }

        public List<Budget> GetBudgets(string userId)
        {
            return budgets.Where(b => b.UserId == userId).ToList();
        }

        public void AddSpent(string userId, string category, decimal amount)
        {
            var budget = budgets.FirstOrDefault(b => b.UserId == userId && b.Category == category);
            if (budget != null)
            {
                budget.Spent += amount;
            }
        }
    }
}