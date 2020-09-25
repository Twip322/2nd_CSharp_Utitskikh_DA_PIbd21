using System;
using System.Collections.Generic;
using System.Text;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.ViewModels;

namespace DeliveryShopBusinessLogic.Interfaces
{
    public interface IMealLogic
    {
        List<MealViewModel> Read(MealBindingModel model);
        void CreateOrUpdate(MealBindingModel model);
        void Delete(MealBindingModel model);
    }
}
