using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;using DeliveryShopBusinessLogic.Attributes;

namespace DeliveryShopBusinessLogic.ViewModels
{
    public class MealViewModel:BaseViewModel
    {
        [Column(title: "Название набора", width: 150)]
        public string ProductName { get; set; }
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }        public override List<string> Properties() => new List<string> { "Id", "ProductName", "Price" };
    }
}
