﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliveryShopBusinessLogic.BusinessLogics;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopListImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace DeliveryShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IDishLogic, DishLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMealLogic, MealLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
