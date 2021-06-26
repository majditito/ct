using Coffee.DAL.Entities;
using Coffee.DAL.Repositories;
using Coffee.Services.Implementations;
using Coffee.Services.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace CoffeeTest
{
    public class PriceOrderTest
    {
        private IDrinkService _drinkService;

        [SetUp]
        public void Setup()
        {
            var productRepository = new ProductRepository();
            var transactionRepository = new TransactionHistoryRepository();
            _drinkService = new DrinkService(productRepository, transactionRepository);
        }

        [Test]
        public void OrderTeaWithExactAmount()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "tea",
                Sugar = 2,
                InsertedMoney = 40,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "T:2:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderTeaWithMissingMoney()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "tea",
                Sugar = 2,
                InsertedMoney = 30,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "M:Missing 10 cents to the drink maker";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderCoffeeWithoutExactMoney()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "coffee",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "C::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderExtraHotCoffeeWithMissingMoney()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "coffee",
                Sugar = 1,
                InsertedMoney = 30,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "M:Missing 30 cents to the drink maker";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }
    }
}