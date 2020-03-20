using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryShopDataBaseImplement.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual AddDishMeal ProductComponent { get; set; }
        public virtual Order Order { get; set; }
    }
}
