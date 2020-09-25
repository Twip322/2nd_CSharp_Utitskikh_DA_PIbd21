using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DeliveryShopBusinessLogic.Attributes;

namespace DeliveryShopBusinessLogic.ViewModels
{
    public class DishViewModel:BaseViewModel
    {
        [Column(title: "Название блюда", width: 150)]
        public string ComponentName { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "ComponentName" };

    }
}
