using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Dashboard
{
    [Authorize(Policy = "Administrator")]

    public class AllOrdersModel : PageModel
    {
        private readonly IOrder _orders;

        public AllOrdersModel(IOrder orders)
        {
            _orders = orders;
        }
        [BindProperty]
        public List<Order> Orders { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Orders = await _orders.GetAllOrders();
            return Page();
        }
    }
}