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
    public class ReceiptModel : PageModel
    {
        private readonly IOrder _order;

        public ReceiptModel(IOrder order)
        {
            _order = order;
        }
        [BindProperty]
        public Order Order { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if (id == 0)
            {
                Order = await _order.GetOrder(User.Identity.Name);
            }
            else
            {
            Order = await _order.GetOrder(id);

            }
            return Page();
        }
    }
}