using System;
using System.Collections.Generic;
using System.Linq;
using FinanceApp.Models;

namespace FinanceApp.Services
{
    public class TransactionService
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transaction.Id = Guid.NewGuid().ToString();
            transactions.Add(transaction);
        }

        public List<Transaction> GetTransactions(string userId)
        {
            return transactions.Where(t => t.UserId == userId).ToList();
        }
    }
}