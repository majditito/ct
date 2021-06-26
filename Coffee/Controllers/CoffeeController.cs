using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.DAL.Entities;
using Coffee.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Coffee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public string Get()
        {
            return "Test";
        }

        [HttpGet("order/standard")]
        public string OrderDrink()
        {
            var request = new OrderRequest
            {
                ProductName = "tea",
                Sugar = 2,
                InsertedMoney = 60,
                ExtraHot = false
            };
            return _drinkService.OrderDrink(request);
        }

        [HttpPost("order")]
        public string OrderProduct([FromBody]OrderRequest orderRequest)
        {
            return _drinkService.OrderDrink(orderRequest);
        }

        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            return _drinkService.GetAllAvailableProducts();
        }

        [HttpGet("report")]
        public dynamic GetReport()
        {
            return _drinkService.GetActualReport();
        }
    }
}
