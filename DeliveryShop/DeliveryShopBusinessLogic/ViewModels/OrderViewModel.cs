using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DeliveryShopBusinessLogic.Enums;
using Unity;
using System.Runtime.Serialization;

namespace DeliveryShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? ClientId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("Изделие")]
        public string ProductName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Рабочий")]
        public string ImplementerFIO { set; get; }
        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
        public int? ImplementerId { set; get; }
    }
}
