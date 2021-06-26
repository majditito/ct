using Coffee.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DAL.Repositories
{
    public class ProductRepository
    {
        public ProductRepository()
        {
            this.Products = new List<Product>()
            {
                new Product("C","Coffee",60),
                new Product("T","Tea",40),
                new Product("H","Chocolate",50),
                new Product("O","OrangeJuice",60,false)
            };
        }

        IEnumerable<Product> Products { get; set; }

        public IEnumerable<Product> GetProducts()
        {
            return this.Products;
        }

        public Product GetProductByName(string productName)
        {
            return this.Products.FirstOrDefault(product => product.Name.ToUpper() == productName.ToUpper());
        }
    }
}
