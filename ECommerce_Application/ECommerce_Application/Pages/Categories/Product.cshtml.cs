using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Categories
{
    public class ProductModel : PageModel
    {
        private readonly IProduct _product;
        private readonly ICartItem _cartItem;
        private readonly ICart _cart;
        private readonly UserManager<Customer> _userManager;

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public int ProductId { get; set; }


        public ProductModel(IProduct product, ICartItem cartItem, ICart cart, UserManager<Customer> userManager)
        {
            _product = product;
            _cartItem = cartItem;
            _cart = cart;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            Product product = await _product.GetProduct(id);
            Product = product;
            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return new RedirectToPageResult("/Account/Login");
            }
            var cart = await _cart.GetCart(user.Email);
            await _cartItem.AddProductToCart(Product, cart, Quantity);
            Product.Quantity = 0;

            await _product.UpdateProduct(Product);

            return Page();
        }
    }
}