using System;
using FinanceApp.Models;
using FinanceApp.Services;

namespace FinanceApp.Controllers
{
    public class FinanceController
    {
        private readonly UserService _userService = new UserService();
        private readonly TransactionService _transactionService = new TransactionService();
        private readonly BudgetService _budgetService = new BudgetService();

        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (_userService.Register(username, password))
            {
                Console.WriteLine("User registered successfully.");
            }
            else
            {
                Console.WriteLine("Username already taken.");
            }
        }

        public User Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User user = _userService.Login(username, password);
            if (user != null)
            {
                Console.WriteLine("Login successful.");
                return user;
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
                return null;
            }
        }

        public void AddTransaction(User user)
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter category: ");
            string category = Console.ReadLine();
            Console.Write("Is this income? (yes/no): ");
            bool isIncome = Console.ReadLine().ToLower() == "yes";

            var transaction = new Transaction
            {
                UserId = user.Username,
                Description = description,
                Amount = amount,
                Category = category,
                Date = DateTime.Now,
                IsIncome = isIncome
            };

            _transactionService.AddTransaction(transaction);
            if (!isIncome)
            {
                _budgetService.AddSpent(user.Username, category, amount);
            }

            Console.WriteLine("Transaction added successfully.");
        }

        public void ViewTransactions(User user)
        {
            var transactions = _transactionService.GetTransactions(user.Username);
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"{transaction.Date.ToShortDateString()} - {transaction.Description}: {transaction.Amount} ({transaction.Category})");
            }
        }

        public void SetBudget(User user)
        {
            Console.Write("Enter category: ");
            string category = Console.ReadLine();
            Console.Write("Enter budget amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            _budgetService.SetBudget(user.Username, category, amount);
            Console.WriteLine("Budget set successfully.");
        }

        public void ViewBudgets(User user)
        {
            var budgets = _budgetService.GetBudgets(user.Username);
            foreach (var budget in budgets)
            {
                Console.WriteLine($"{budget.Category}: {budget.Spent}/{budget.Amount}");
            }
        }
    }
}