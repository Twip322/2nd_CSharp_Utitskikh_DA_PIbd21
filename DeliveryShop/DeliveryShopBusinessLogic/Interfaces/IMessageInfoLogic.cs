using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryShopBusinessLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}
