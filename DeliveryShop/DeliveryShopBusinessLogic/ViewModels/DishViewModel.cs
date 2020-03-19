using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace DeliveryShopBusinessLogic.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название блюда")]
        public string ComponentName { get; set; }
    }
}
