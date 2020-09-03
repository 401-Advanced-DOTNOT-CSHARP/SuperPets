using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Dashboard
{
    public class AllProductsModel : PageModel
    {
        private readonly IProduct _product;

        public AllProductsModel(IProduct product)
        {
            _product = product;
        }
        [BindProperty]
        public List<Product> Products { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Products = await _product.GetProducts();
            return Page();
        }
    }
}