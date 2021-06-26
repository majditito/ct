using Coffee.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Services.Interfaces
{
    public interface IDrinkService
    {
        public IEnumerable<Product> GetAllAvailableProducts();
        public Product GetProduct(string productName);
        public string OrderDrink(OrderRequest request);
        public dynamic GetActualReport();

    }
}
