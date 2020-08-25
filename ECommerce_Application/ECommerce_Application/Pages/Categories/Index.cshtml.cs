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
    public class IndexModel : PageModel
    {
        private readonly ICartItem _cartItem;
        private readonly ICart _cart;

        public IndexModel(ICart cart, ICartItem cartItem)
        {
            _cart = cart;
            _cartItem = cartItem;
        }
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


        public async Task<IActionResult> OnGet()
        {
;           Cart = await _cart.GetCart(User.Identity.Name);

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            CartItem = await _cartItem.GetCartItem(ProductId, CartId);
            await _cartItem.RemoveProductFromCart(CartItem.Product, CartItem.Cart);

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            CartItem = await _cartItem.GetCartItem(ProductId, CartId);
            await _cartItem.UpdateCartQuantityAndPrice(CartItem.Product, CartItem.Cart, Quantity);
            return new RedirectToPageResult("/Categories/Index");
        }
    }
}
