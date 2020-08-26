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
using Microsoft.Extensions.Configuration;
using static ECommerce_Application.Pages.Account.RegisterModel;

namespace ECommerce_Application.Pages.Categories
{
    /// <summary>
    /// References the Page
    /// </summary>
    public class CheckoutModel : PageModel
    {
        private readonly IOrder _order;
        private readonly ICart _cart;
        private readonly IPayment _payment;
        private IEmailSender _sender;
        private readonly IConfiguration _config;
        private UserManager<Customer> _usermanager;


        public CheckoutModel(IOrder order, ICart cart, IPayment payment, IEmailSender sender, IConfiguration config)
        {
            _order = order;
            _cart = cart;
            _payment = payment;
            _sender = sender;
            _config = config;

        }

        /// <summary>
        /// All these properties are required to checkkout
        /// </summary>
        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public Cart Cart { get; set; }
        [BindProperty]
        public RegisterViewModel Registration { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public bool Payment { get; set; }




        /// <summary>
        /// Get the users information and return the page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGet()
        {
           Cart = await _cart.GetCart(User.Identity.Name);
            return Page();
        }

        /// <summary>
        /// Post the users order information on the page, and send them a receipt with said information
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            Order.OrderNumber = $"{Guid.NewGuid().ToString()}{Order.Id}";
            Cart = await _cart.GetCart(User.Identity.Name);
            string subject = $"Receipt of purchase from SuperPets for {Order.FirstName}";
            Order.Date = DateTime.Now;
            string htmlMessage = $"<h1>Your Order {Order.Date}!</h1><br><ul><li>{Order.OrderNumber}</li></ul><ul>";
            foreach (var item in Cart.CartItems)
            {
                htmlMessage += $"<li><h2>Name: {item.Product.Name}</h2>" +
                    $"<h2>Quantity: {item.Quantity}</h2>" +
                    $"<h2>Price: {item.Quantity * item.Product.Price}</h2></li>";
            }
            htmlMessage += $"<li>Total: {Cart.Price}</ul><br><ul><li>Shipping Address: {Order.Address}</li><li>City: {Order.City}</li><li>State: {Order.State}</li><li>ZipCode: {Order.ZipCode}</li></ul>";
            string card = "Card:";
            card += Name;
            card += ":Number";
            Order.Cart = Cart;
            await _order.CreateOrder(Order);
            string Expiration = "0221";
            string CVC = "012";
            if (Name == "My Credit Card")
            {
                CVC = "1234";
            }

            var payment = await _payment.Run(Order.UserEmail, card, Expiration, CVC);
            if(payment == "Failed")
            {
                Payment = true;
                return Page();
            }
            await _sender.SendEmailAsync(Order.UserEmail, subject, htmlMessage);

            Cart.Date = DateTime.Now;
            Cart cart = new Cart()
            {
                UserEmail = User.Identity.Name,
                
                Date = DateTime.Now
            };
            await _cart.CreateCart(cart);

            return new RedirectToPageResult($"/Categories/Receipt");
        }
    }
}