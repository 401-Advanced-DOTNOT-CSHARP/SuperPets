using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Categories
{
    public class AllModel : PageModel
    {
        private readonly IProduct _product;
        private readonly IImage _image;

        [BindProperty]
        public List<Product> Products { get; set; }

        public AllModel(IProduct product)
        {
            _product = product;
        }
        public async Task<IActionResult> OnGet()
        {
            Products = await _product.GetProducts();
            return Page();
        }
    }
}