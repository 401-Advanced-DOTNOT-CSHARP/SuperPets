using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Application.Controllers
{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }



    }
}
