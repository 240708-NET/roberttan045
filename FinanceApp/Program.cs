using System;
using FinanceApp.Controllers;
using FinanceApp.Models;

namespace FinanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FinanceController financeController = new FinanceController();
            User user = null;

            while (user == null)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        financeController.Register();
                        break;
                    case "2":
                        user = financeController.Login();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }

            string action;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. Set Budget");
                Console.WriteLine("4. View Budgets");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        financeController.AddTransaction(user);
                        break;
                    case "2":
                        financeController.ViewTransactions(user);
                        break;
                    case "3":
                        financeController.SetBudget(user);
                        break;
                    case "4":
                        financeController.ViewBudgets(user);
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            } while (action != "5");
        }
    }
}