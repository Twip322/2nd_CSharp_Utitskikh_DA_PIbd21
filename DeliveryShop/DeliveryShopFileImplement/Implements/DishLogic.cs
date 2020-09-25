using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using DeliveryShopListImplement.Models;


namespace DeliveryShopFileImplement.Implements
{
    public class DishLogic:IDishLogic
    {
        private readonly FileDataListSingleton source;
        public DishLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            Dish element = source.Components.FirstOrDefault(rec => rec.ComponentName
           == model.ComponentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Components.Count > 0 ? source.Components.Max(rec =>
               rec.Id) : 0;
                element = new Dish { Id = maxId + 1 };
                source.Components.Add(element);
            }
            element.ComponentName = model.ComponentName;
        }
        public void Delete(DishBindingModel model)
        {
            Dish element = source.Components.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Components.Remove(element);
            }
            else
            {
            throw new Exception("Элемент не найден");
            }
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            return source.Components
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
