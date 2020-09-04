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
    /// <summary>
    /// References the page
    /// </summary>
    public class ProductModel : PageModel
    {
        private readonly IProduct _product;
        private readonly ICartItem _cartItem;
        private readonly ICart _cart;
        private readonly UserManager<Customer> _userManager;


        /// <summary>
        /// Properties for the product
        /// </summary>
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public bool IsAvailable { get; set; }


        public ProductModel(IProduct product, ICartItem cartItem, ICart cart, UserManager<Customer> userManager)
        {
            _product = product;
            _cartItem = cartItem;
            _cart = cart;
            _userManager = userManager;
        }


        /// <summary>
        /// Returns individual products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// On post Add the product to cart
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return new RedirectToPageResult("/Account/Login");
            }

            var cart = await _cart.GetCart(user.Email);


            if (cart == null)
            {
                cart = new Cart()
                {
                    Date = DateTime.Now,
                    UserEmail = User.Identity.Name
                };

                await _cart.CreateCart(cart);

            }

            if (Quantity > Product.Quantity || Quantity <= 0)
            {
                IsAvailable = true;
                return Page();
            }

            if (Quantity <= Product.Quantity && Quantity > 0)
            {
                if (cart.CartItems != null)
                {
                    foreach (var item in cart.CartItems)
                    {
                        if (item.ProductId == Product.Id)
                        {
                            var productExist = await _product.GetProduct(Product.Id);
                            productExist.Quantity = productExist.Quantity - Quantity;
                            _product.UpdateProduct(productExist).Wait();
                            var duplicateCart = await _cartItem.GetCartItem(Product.Id, cart.Id);
                            duplicateCart.Quantity = duplicateCart.Quantity + Quantity;
                            _cartItem.UpdateCartItem(duplicateCart).Wait();
                            cart.Quantity = cart.Quantity + Quantity;
                            cart.Price += Product.Price * Quantity;
                            _cart.UpdateCart(cart).Wait();
                            return Page();


                        }
                    }
                }
                     await _cartItem.AddProductToCart(Product, cart, Quantity);
                    Product.Quantity = Product.Quantity - Quantity;

                    await _product.UpdateProduct(Product);
            }

            return Page();
        }
    }
}