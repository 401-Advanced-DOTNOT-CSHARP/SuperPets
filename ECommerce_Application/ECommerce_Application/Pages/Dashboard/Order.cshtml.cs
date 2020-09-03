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

    public class OrderModel : PageModel
    {
        private readonly IOrder _order;

        public OrderModel(IOrder order)
        {
            _order = order;
        }
        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Order = await _order.GetOrder(id);
            return Page();
        }

    }
}