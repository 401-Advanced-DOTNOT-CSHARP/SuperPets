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

    /// <summary>
    /// References the page
    /// </summary>
    public class AllModel : PageModel
    {
        private readonly IProduct _product;

        [BindProperty]
        public List<Product> Products { get; set; }
        [BindProperty]
        public int Index { get; set; }

        public AllModel(IProduct product)
        {
            _product = product;
        }


        /// <summary>
        /// Return the page full of products when called
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGet()
        {
            Products = await _product.GetProducts();

            return Page();
        }

    }
}