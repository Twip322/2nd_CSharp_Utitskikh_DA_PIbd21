using System;
using System.Collections.Generic;
using System.Text;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using DeliveryShopListImplement.Models;

namespace DeliveryShopListImplement.Implements
{
    public class DishLogic : IDishLogic
    {
        private readonly DataListSingleton source;
        public DishLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            Dish tempComponent = model.Id.HasValue ? null : new Dish
            {
                Id = 1
            };
            foreach (var component in source.Dishes)
            {
                if (component.ComponentName == model.ComponentName && component.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (!model.Id.HasValue && component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
                else if (model.Id.HasValue && component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempComponent == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempComponent);
            }
            else
            {
                source.Dishes.Add(CreateModel(model, tempComponent));
            }
        }
        public void Delete(DishBindingModel model)
        {
            for (int i = 0; i < source.Meals.Count; ++i)
            {
                if (source.Meals[i].Id == model.Id.Value)
                {
                    source.Meals.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            List<DishViewModel> result = new List<DishViewModel>();
            foreach (var component in source.Dishes)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private Dish CreateModel(DishBindingModel model, Dish component)
        {
            component.ComponentName = model.ComponentName;
            return component;
        }
        private DishViewModel CreateViewModel(Dish component)
        {
            return new DishViewModel
            {
                Id = component.Id,
                ComponentName = component.ComponentName
            };
        }
    }
}
