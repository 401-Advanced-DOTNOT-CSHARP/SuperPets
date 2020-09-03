using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Account
{
    public class AllOrdersModel : PageModel
    {
        private readonly IOrder _order;

        public AllOrdersModel(IOrder order)
        {
            _order = order;
        }

        [BindProperty]
        public List<Order> Orders { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Orders = await _order.GetAllOrders(User.Identity.Name);
            return Page();
        }
    }
}