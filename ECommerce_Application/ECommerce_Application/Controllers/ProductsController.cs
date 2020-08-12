using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce_Application.Models;
using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Interfaces;
using ECommerce_Application.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Application.Controllers
{
    public class ProductController : Controller
    {
        private IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }


    }
}
