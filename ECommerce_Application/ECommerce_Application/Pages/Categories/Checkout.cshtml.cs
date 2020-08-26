using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ECommerce_Application.Pages.Account.RegisterModel;

namespace ECommerce_Application.Pages.Categories
{
    public class CheckoutModel : PageModel
    {
        private readonly IOrder _order;
        private readonly ICart _cart;
        private readonly ICartItem _cartitem;
        private readonly IPayment _payment;
        private IEmailSender _sender;

        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public Cart Cart { get; set; }


        [BindProperty]
        public RegisterViewModel Registration { get; set; }

        public CheckoutModel(IOrder order, ICart cart, IPayment payment, IEmailSender sender)
        {
            _order = order;
            _cart = cart;
            _payment = payment;
            _sender = sender;
        }


        public async Task<IActionResult> OnGet()
        {
           Cart = await _cart.GetCart(User.Identity.Name);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            Cart = await _cart.GetCart(User.Identity.Name);

            string subject = $"Receipt of purchase from SuperPets for {Order.FirstName}";
            string htmlMessage = $"Your Order was purchased on {Order.Date}!</h1><br>Order Id: {Order.CartId}</li></ul></h1><br><ul><li>Cart: {Cart.CartItems}</li></ul><ul><li>Shipping Address: {Order.Address}<br> {Order.City}<br>{Order.State}</li></ul>";
            Order.Date = DateTime.Now;
            Order.Cart = Cart;
            await _order.CreateOrder(Order);
            var payment = await _payment.Run(Order.UserEmail);
            await _sender.SendEmailAsync(Order.UserEmail, subject, htmlMessage);

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