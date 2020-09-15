using DeliveryShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryShopDataBaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }

        public virtual Meal Product { get; set; }
    }
}
