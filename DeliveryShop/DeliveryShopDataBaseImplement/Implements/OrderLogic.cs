﻿using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using DeliveryShopDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryShopDataBaseImplement.Implements
{
    public class OrderLogic:IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new DeliveryShopDataBase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.ClientId = model.ClientId == 0 ? element.ClientId : model.ClientId;
                element.ProductId = model.ProductId == 0 ? element.ProductId : model.ProductId;
                element.Count = model.Count;
                element.ClientFIO = model.ClientFIO;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new DeliveryShopDataBase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new DeliveryShopDataBase())
            {
                return context.Orders
                .Where(rec => model == null || (rec.Id == model.Id && model.Id.HasValue)
                || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ProductId = rec.ProductId,
                    ClientFIO = rec.ClientFIO,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ProductName = context.Products.FirstOrDefault(recS => recS.Id ==
                    rec.ProductId).ProductName,
                })
            .ToList();
            }
        }
    }
}
