using Coffee.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DAL.Repositories
{
    public class TransactionHistoryRepository
    {
        public TransactionHistoryRepository()
        {
            this.Transactions = new List<TransactionHistory>() { };
        }

        IList<TransactionHistory> Transactions { get; set; }

        public IList<TransactionHistory> GetAllTransactionHistory()
        {
            return this.Transactions;
        }

        public void AddSuccededTransaction(TransactionHistory transaction)
        {
            if (Transactions == null)
            {
                this.Transactions = new List<TransactionHistory>() { };
            }
            this.Transactions.Add(transaction);
        }
    }
}
