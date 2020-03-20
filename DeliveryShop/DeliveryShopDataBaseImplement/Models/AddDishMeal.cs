using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryShopDataBaseImplement.Models
{
    public class AddDishMeal
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Dish Component { get; set; }
        public virtual Meal Product { get; set; }

    }
}
