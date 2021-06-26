using Coffee.DAL.Entities;
using Coffee.DAL.Repositories;
using Coffee.Services.Implementations;
using Coffee.Services.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace CoffeeTest
{
    public class ExtraHotTests
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
        public void OrderExtraHotTeaWithSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "tea",
                Sugar = 2,
                InsertedMoney = 60,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "Th:2:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderExtraHotTeaWithoutSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "tea",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "Th::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderExtraHotCoffeeWithoutSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "coffee",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "Ch::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderExtraHotCoffeeWithOneSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "coffee",
                Sugar = 1,
                InsertedMoney = 60,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "Ch:1:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderExtraHotChocolateWithOneSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "chocolate",
                Sugar = 1,
                InsertedMoney = 60,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "Hh:1:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderExtraHotChocolateWithoutSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "chocolate",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "Hh::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderExtraHotOrangeJuice()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "orangeJuice",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = true
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "O::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }
    }
}