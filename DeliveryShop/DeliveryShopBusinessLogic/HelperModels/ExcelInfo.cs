using DeliveryShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDishMealViewModel> ProductComponents { get; set; }

    }
}
