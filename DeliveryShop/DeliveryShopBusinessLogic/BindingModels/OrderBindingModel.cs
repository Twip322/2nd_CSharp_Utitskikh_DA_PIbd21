﻿using System;
using System.Collections.Generic;
using System.Text;
using DeliveryShopBusinessLogic.Enums;

namespace DeliveryShopBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public int ProductId { get; set; }
        public int? ImplementerId { get; set; }
        public string ImplementerFIO { set; get; }
        public string ClientFIO { set; get; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? FreeOrder { get; set; }
    }
}
