using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using DeliveryShopDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryShopDataBaseImplement.Implements
{
    public class DishLogic:IDishLogic
    {
        public void CreateOrUpdate(DishBindingModel model)
        {
            using (var context = new DeliveryShopDataBase())
            {
                Dish element = context.Components.FirstOrDefault(rec =>
               rec.ComponentName == model.ComponentName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Components.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Dish();
                    context.Components.Add(element);
                }
                element.ComponentName = model.ComponentName;
                context.SaveChanges();
            }
        }
        public void Delete(DishBindingModel model)
        {
            using (var context = new DeliveryShopDataBase())
            {
                Dish element = context.Components.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Components.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            using (var context = new DeliveryShopDataBase())
            {
                return context.Components
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new DishViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName
                })
                .ToList();
            }
        }
    }
}
