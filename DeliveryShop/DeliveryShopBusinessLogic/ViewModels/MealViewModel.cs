using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DeliveryShopBusinessLogic.ViewModels
{
    public class MealViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название набора")]
        public string ProductName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
