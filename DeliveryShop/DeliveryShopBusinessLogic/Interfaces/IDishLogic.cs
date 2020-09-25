using System;
using System.Collections.Generic;
using System.Text;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.ViewModels;

namespace DeliveryShopBusinessLogic.Interfaces
{
    public interface IDishLogic
    {
        List<DishViewModel> Read(DishBindingModel model);
        void CreateOrUpdate(DishBindingModel model);
        void Delete(DishBindingModel model);

    }
}
