using Coffee.DAL.Entities;
using Coffee.DAL.Repositories;
using Coffee.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Services.Implementations
{
    public class DrinkService : IDrinkService
    {
        private readonly ProductRepository _productRepository;
        private readonly TransactionHistoryRepository _transactionRepository;

        public DrinkService(ProductRepository productRepository, TransactionHistoryRepository transactionRepository)
        {
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Product> GetAllAvailableProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(string productName)
        {
            return _productRepository.GetProductByName(productName);
        }

        public string OrderDrink(OrderRequest request)
        {
            Product product = GetProduct(request.ProductName);
            if (product != null)
            {
                var result = product.Order(request.Sugar, request.InsertedMoney, request.ExtraHot);
                if (result.Success)
                {
                    this.AddTransactionHistory(product);
                }
                return result.Message;
            }
            else
            {
                return "M:Unfound drink";
            }
        }

        private void AddTransactionHistory(Product product)
        {
            TransactionHistory transaction = new TransactionHistory
            {
                ProductName = product.Name,
                ProductPrice = product.Price,
                TransactionTimeStamp = DateTime.Now
            };
            _transactionRepository.AddSuccededTransaction(transaction);
        }

        public dynamic GetActualReport()
        {
            var history = _transactionRepository.GetAllTransactionHistory();
            var totalPrice = history.Sum(tr => tr.ProductPrice);
            return new
            {
                Report = history
                            .GroupBy(element => element.ProductName)
                            .Select(product => new
                            {
                                Product = product.Key,
                                Total = product.Count()
                            }),
                Total = GetDisplayStringForPrice(totalPrice)
            };
        }

        private string GetDisplayStringForPrice(int cents)
        {
            var doublePrice = (double)cents / 100;
            return doublePrice.ToString() + " €";
        }
    }
}
