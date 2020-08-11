using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICereal _cereal;

        public ProductsController(ICereal cereal)
        {
            _cereal = cereal;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CerealDTO cerealDTO)
        {

            _cereal.CreateCereal(cerealDTO);

            return RedirectToAction("Index");

        }
    }
}
