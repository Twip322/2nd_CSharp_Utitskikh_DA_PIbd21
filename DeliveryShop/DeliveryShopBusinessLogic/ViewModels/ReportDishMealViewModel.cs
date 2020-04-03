﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryShopBusinessLogic.ViewModels
{
    public class ReportDishMealViewModel
    {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Products { get; set; }
    }
}
