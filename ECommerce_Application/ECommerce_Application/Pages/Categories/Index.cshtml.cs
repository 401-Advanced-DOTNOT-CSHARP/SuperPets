using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerce_Application.Data;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;

namespace ECommerce_Application.Pages.Categories
{
    /// <summary>
    /// References the page
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ICartItem _cartItem;
        private readonly ICart _cart;
        private readonly IProduct _product;

        public IndexModel(ICart cart, ICartItem cartItem, IProduct product)
        {
            _cart = cart;
            _cartItem = cartItem;
            _product = product;
        }


        /// <summary>
        /// Required properties for Cart Index page
        /// </summary>
        [BindProperty]
        public Cart Cart { get;set; }
        [BindProperty]
        public CartItem CartItem { get; set; }
        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public int CartId { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public Product Product { get; set; }


        [BindProperty]
        public bool IsAvailable { get; set; }


        /// <summary>
        /// Get the cart based on the users info
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGet()
        {
;           Cart = await _cart.GetCart(User.Identity.Name);

            return Page();
        }


        /// <summary>
        /// Delete the information based on user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete()
        {
            CartItem = await _cartItem.GetCartItem(ProductId, CartId);
            await _cartItem.RemoveProductFromCart(CartItem.Product, CartItem.Cart);

            return RedirectToPage("./Index");
        }


        /// <summary>
        /// Update based upon user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostUpdate()
        {
            Cart = await _cart.GetCart(User.Identity.Name);
            Product = await _product.GetProduct(ProductId);
            CartItem = await _cartItem.GetCartItem(ProductId, CartId);

            if (CartItem == null)
            {
                IsAvailable = true;
                return Page();
            }
            if (Quantity <= Product.Quantity && Quantity > 0)
            {
            await _cartItem.UpdateCartQuantityAndPrice(CartItem.Product, CartItem.Cart, Quantity);
            return new RedirectToPageResult("/Categories/Index");

            }
            if (Quantity > Product.Quantity || Quantity <= 0)
            {
                IsAvailable = true;
                return Page();
            }
            return Page();
        }
    }
}
