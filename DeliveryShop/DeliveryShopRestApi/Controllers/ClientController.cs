﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryShopBusinessLogic.BindingModels;
using DeliveryShopBusinessLogic.Interfaces;
using DeliveryShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientLogic _logic;
        public ClientController(IClientLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public ClientViewModel Login(string login, string password) => _logic.Read(new ClientBindingModel
        {
            Email = login,
            Password = password
        })?[0];
        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);
        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
}
