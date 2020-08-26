using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Data;
using ECommerce_Application.Models;
using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Interfaces;
using ECommerce_Application.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Application.Controllers
{

    public class HomeController : Controller
    {
        private readonly IProduct _productService;

        /// <summary>
        /// Home controller displays the products, so we bring in the private context
        /// </summary>
        /// <param name="productService"></param>
        public HomeController(IProduct productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get the home index and return view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }



    }
}
