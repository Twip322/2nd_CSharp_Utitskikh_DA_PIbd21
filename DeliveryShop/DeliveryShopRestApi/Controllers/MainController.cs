using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.BusinessLogics;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using DeliveryShopRestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IOrderLogic _order;
        private readonly IMealLogic _meal;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IMealLogic meal, MainLogic main)
        {
            _order = order;
            _meal = meal;
            _main = main;
        }
        [HttpGet]
        public List<MealModel> GetMealList() => _meal.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public MealModel GetMeal(int MealId) => Convert(_meal.Read(new MealBindingModel
        {
            Id = MealId
        })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        {
            ClientId = clientId
        });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
        private MealModel Convert(MealViewModel model)
        {
            if (model == null) return null;
            return new MealModel
            {
                Id = model.Id,
                ProductName = model.ProductName,
                Price = model.Price
            };
        }
    }
}
