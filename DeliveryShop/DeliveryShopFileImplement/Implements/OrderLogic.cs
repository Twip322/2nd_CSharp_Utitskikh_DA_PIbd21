using System;
using System.Collections.Generic;
using System.Text;
using DeliveryShopListImplement.Models;
using DeliveryShopBusinessLogic.ViewModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.BindingModels;
using System.Linq;

namespace DeliveryShopFileImplement.Implements
{
    public class OrderLogic:IOrderLogic
    {
        
            private readonly FileDataListSingleton source;

            public OrderLogic()
            {
                source = FileDataListSingleton.GetInstance();
            }

            public void CreateOrUpdate(OrderBindingModel model)
            {
                Order order;
                if (model.Id.HasValue)
                {
                    order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (order == null)
                        throw new Exception("Элемент не найден");
                    order.ProductId = model.ProductId;
                    order.Count = model.Count;
                    order.DateCreate = model.DateCreate;
                    order.DateImplement = model.DateImplement;
                    order.Status = model.Status;
                    order.Sum = model.Sum;
                    order.ClientId = (int)model.ClientId;
                }
                else
                {
                    int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
                    order = new Order { Id = maxId + 1 };
                    order.ProductId = model.ProductId;
                    order.Count = model.Count;
                    order.DateCreate = model.DateCreate;
                    order.DateImplement = model.DateImplement;
                    order.Status = model.Status;
                    order.Sum = model.Sum;
                    order.ClientId = (int)model.ClientId;
                    source.Orders.Add(order);
                }
            }

            public void Delete(OrderBindingModel model)
            {
                Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order != null)
                {
                    source.Orders.Remove(order);
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }

            public List<OrderViewModel> Read(OrderBindingModel model)
            {
                return source.Orders
                .Where(rec => model == null || rec.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                 || model.ClientId.HasValue && rec.ClientId == model.ClientId)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFIO = source.Clients.FirstOrDefault(recC => recC.Id == rec.ClientId)?.ClientFIO,
                    ProductId = rec.ProductId,
                    ProductName = source.Products.FirstOrDefault((r) => r.Id == rec.ProductId).ProductName,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    Sum = rec.Sum
                }).ToList();
            }
        }
}
