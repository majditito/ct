using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DAL.Entities
{
    public class OrderRequest
    {
        public int InsertedMoney { get; set; }
        public int Sugar { get; set; }
        public string ProductName { get; set; }
        public bool ExtraHot { get; set; }
    }
}
