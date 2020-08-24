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
    public class CheckoutModel : PageModel
    {
        private readonly IOrder _order;
        private readonly ICart _cart;
        private readonly IPayment _payment;

        public CheckoutModel(IOrder order, ICart cart, IPayment payment)
        {
            _order = order;
            _cart = cart;
            _payment = payment;
        }
        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public Cart Cart { get; set; }




        public async Task<IActionResult> OnGet()
        {
           Cart = await _cart.GetCart(User.Identity.Name);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            Order.Date = DateTime.Now;
            Order.Cart = Cart;
            await _order.CreateOrder(Order);
            var payment = await _payment.Run(Order.UserEmail);
            Cart.Date = DateTime.Now;
            Cart cart = new Cart()
            {
                UserEmail = User.Identity.Name,
                Date = DateTime.Now
            };
            await _cart.CreateCart(cart);

            return new RedirectToPageResult("/");
        }
    }
}