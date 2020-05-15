using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.HelperModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IMealLogic productLogic;
        private readonly IOrderLogic orderLogic;


        public ReportLogic(IMealLogic productLogic, IDishLogic componentLogic,
       IOrderLogic orderLogic)
        {
            this.productLogic = productLogic;
            this.orderLogic = orderLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportDishMealViewModel> GetProductComponent()
        {
            var products = productLogic.Read(null);
            var list = new List<ReportDishMealViewModel>();
           foreach(var product in products)
            {
                foreach(var dish in product.ProductComponents)
                {
                    list.Add(new ReportDishMealViewModel
                    {
                        ProductName = product.ProductName,
                        DishName = dish.Value.Item1,
                        Count = dish.Value.Item2
                    });
                }
            }
            return list;
        }


      


        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<DateTime, ReportOrdersViewModel>> GetOrders(ReportBindingModel model)
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
           .GroupBy(x => x.DateCreate.Date);
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
                Title = "Список Наборов",
                Products = productLogic.Read(null)
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
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                FileName = model.FileName,
                Title = "Заказы",
                Orders = GetOrders(model)
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
                Title = "Список необходимых блюд для наборов",
                ProductComponent = GetProductComponent()
            });

        }

    }
}
