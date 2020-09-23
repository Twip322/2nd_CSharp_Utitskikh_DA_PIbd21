using System;
using System.Collections.Generic;
using System.Text;
using DeliveryShopListImplement.Models;

namespace DeliveryShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Dish> Dishes { get; set; }
        public List<Order> Orders { get; set; }
        public List<Meal> Meals { get; set; }
        public List<AddDishMeal> AddMealsDishes { get; set; }
        public List<Client> Clients { get; set; }
        private DataListSingleton()
        {
            Dishes = new List<Dish>();
            Orders = new List<Order>();
            Meals = new List<Meal>();
            AddMealsDishes = new List<AddDishMeal>();
            Clients = new List<Client>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}
