using System;
using System.Collections.Generic;
using System.Text;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using DeliveryShopListImplement.Models;

namespace DeliveryShopListImplement.Implements
{
    public class MealLogic : IMealLogic
    {
        private readonly DataListSingleton source;
        public MealLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(MealBindingModel model)
        {
            Meal tempProduct = model.Id.HasValue ? null : new Meal { Id = 1 };
            foreach (var product in source.Meals)
            {
                if (product.ProductName == model.ProductName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Meals.Add(CreateModel(model, tempProduct));
            }
        }
        public void Delete(MealBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.AddMealsDishes.Count; ++i)
            {
                if (source.AddMealsDishes[i].ProductId == model.Id)
                {
                    source.AddMealsDishes.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Dishes.Count; ++i)
            {
                if (source.Dishes[i].Id == model.Id)
                {
                    source.Dishes.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Meal CreateModel(MealBindingModel model, Meal product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.AddMealsDishes.Count; ++i)
            {
                if (source.AddMealsDishes[i].Id > maxPCId)
                {
                    maxPCId = source.AddMealsDishes[i].Id;
                }
                if (source.AddMealsDishes[i].ProductId == product.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.ProductComponents.ContainsKey(source.AddMealsDishes[i].ComponentId))
                    {
                        // обновляем количество
                        source.AddMealsDishes[i].Count =
                        model.ProductComponents[source.AddMealsDishes[i].ComponentId].Item2;

                        model.ProductComponents.Remove(source.AddMealsDishes[i].ComponentId);
                    }
                    else
                    {
                        source.AddMealsDishes.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.ProductComponents)
            {
                source.AddMealsDishes.Add(new AddDishMeal
                {
                    Id = ++maxPCId,
                    ProductId = product.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        public List<MealViewModel> Read(MealBindingModel model)
        {
            List<MealViewModel> result = new List<MealViewModel>();
            foreach (var component in source.Meals)
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
        private MealViewModel CreateViewModel(Meal product)
        {
            Dictionary<int, (string, int)> productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in source.AddMealsDishes)
            {
                if (pc.ProductId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Meals)
                    {
                        if (pc.ComponentId == component.Id)
                        {
                            componentName = component.ProductName;
                            break;
                        }
                    }
                    productComponents.Add(pc.ComponentId, (componentName, pc.Count));
                }
            }
            return new MealViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductComponents = productComponents
            };
        }
    }
}
