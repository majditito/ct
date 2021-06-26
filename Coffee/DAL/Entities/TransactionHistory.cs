using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DAL.Entities
{
    public class TransactionHistory
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public DateTime TransactionTimeStamp { get; set; }
    }
}
