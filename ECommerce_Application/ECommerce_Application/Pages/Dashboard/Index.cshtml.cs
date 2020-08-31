using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerce_Application.Data;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Authorization;
using ECommerce_Application.Models.Interfaces;

namespace ECommerce_Application.Pages.Dashboard
{

    /// <summary>
    /// Only admin can edit
    /// </summary>
    [Authorize(Policy = "Administrator")]

    public class IndexModel : PageModel
    {
        private readonly IOrder _order;

        public IProduct _product { get; }

        public IndexModel(IOrder order, IProduct product)
        {
            _order = order;
            _product = product;
        }

        [BindProperty]
        public List<Product> Products { get; set; }
        [BindProperty]
        public List<Order> Orders { get; set; }
        [BindProperty]
        public decimal[] Prices { get; set; }
        [BindProperty]
        public DateTime[] Dates { get; set; }


        /// <summary>
        /// Get the products upon request
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _order.GetAllOrders();
            decimal[] prices = new decimal[Orders.Count];
            DateTime[] dates = new DateTime[Orders.Count];

            Products = await _product.GetProducts();
            for(var i = 0; i < Orders.Count; i++)
            {
                prices[i] = Orders[i].Cart.Price;
            }
            for (var i = 0; i < Orders.Count; i++)
            {
                dates[i] = Orders[i].Date;
            }
            Prices = prices;
            Dates = dates;
            return Page();
        }
    }
}
