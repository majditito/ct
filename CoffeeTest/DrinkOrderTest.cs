using Coffee.DAL.Entities;
using Coffee.DAL.Repositories;
using Coffee.Services.Implementations;
using Coffee.Services.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace CoffeeTest
{
    public class OrderDrinkTests
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
        public void OrderTeaWithSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "tea",
                Sugar = 2,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "T:2:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderTeaWithoutSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "tea",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "T::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderCoffeeWithoutSugar()
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
        public void OrderCoffeeWithOneSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "coffee",
                Sugar = 1,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "C:1:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderChocolateWithOneSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "chocolate",
                Sugar = 1,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "H:1:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderChocolateWithoutSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "chocolate",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "H::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderOrangeJuiceWithoutSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "orangeJuice",
                Sugar = 0,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "O::";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderOrangeJuiceWithSugar()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "orangeJuice",
                Sugar = 2,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "O:2:0";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }

        [Test]
        public void OrderUnfoundDrink()
        {
            OrderRequest orderRequest = new OrderRequest
            {
                ProductName = "unfound",
                Sugar = 2,
                InsertedMoney = 60,
                ExtraHot = false
            };
            var result = _drinkService.OrderDrink(orderRequest);
            const string expected = "M:Unfound drink";
            Assert.AreEqual(result, expected, "Résultat incorrect");
        }
    }
}