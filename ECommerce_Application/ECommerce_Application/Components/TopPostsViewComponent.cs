using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Data;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Application.Components
{
    [ViewComponent]
    public class TopPostsViewComponent : ViewComponent
    {
        private StoreDbContext _context;
        private readonly ICart _cart;

        /// <summary>
        /// View Component private context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cart"></param>
        public TopPostsViewComponent(StoreDbContext context, ICart cart)
        {
            _context = context;
            _cart = cart;
        }

        /// <summary>
        /// Get the cart based upon user email
        /// Return the cart with view compenents
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(string userEmail)
        {
            var cart = await _cart.GetCart(userEmail);

            return View(cart);
        }
    }
}
