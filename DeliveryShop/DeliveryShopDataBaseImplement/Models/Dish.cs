using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace DeliveryShopDataBaseImplement.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string ComponentName { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<AddDishMeal> ProductComponents { get; set; }
    }
}
