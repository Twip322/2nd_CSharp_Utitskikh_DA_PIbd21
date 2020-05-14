using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.HelperModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IDishLogic componentLogic;
        private readonly IMealLogic productLogic;
        private readonly IOrderLogic orderLogic;


        public ReportLogic(IMealLogic productLogic, IDishLogic componentLogic,
       IOrderLogic orderLLogic)
        {
            this.productLogic = productLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportDishMealViewModel> GetProductComponent()
        {
            var components = componentLogic.Read(null);
            var products = productLogic.Read(null);
            var list = new List<ReportDishMealViewModel>();
            foreach (var component in components)
            {
                var record = new ReportDishMealViewModel
                {
                    ComponentName = component.ComponentName,
                    Products = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var product in products)
                {
                    if (product.ProductComponents.ContainsKey(component.Id))
                    {
                        record.Products.Add(new Tuple<string, int>(product.ProductName,
                       product.ProductComponents[component.Id].Item2));
                        record.TotalCount +=
                       product.ProductComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }


        public List<ReportOrdersViewModel> GetOrders()
        {
            return orderLogic.Read(null)
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                ProductName = x.ProductName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }


        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                ProductName = x.ProductName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = componentLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                ProductComponents = GetProductComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPDF.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders()
            });
        }

    }
}
