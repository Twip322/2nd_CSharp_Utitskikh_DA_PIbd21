﻿using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryShopBusinessLogic.Interfaces
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);

        void CreateOrUpdate(ImplementerBindingModel model);

        void Delete(ImplementerBindingModel model);
    }
}
