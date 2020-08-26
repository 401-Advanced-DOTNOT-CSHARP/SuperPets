using ECommerce_Application.Data;
using ECommerce_Application.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Services
{
    /// <summary>
    /// Referencing the Interface CartItem
    /// </summary>
    public class CartItemService : ICartItem
    {
        private readonly StoreDbContext _context;
        private readonly ICart _cart;
        private readonly IProduct _product;

        public CartItemService(StoreDbContext context, ICart cart, IProduct product)
        {
            _context = context;
            _cart = cart;
            _product = product;
        }

        /// <summary>
        /// Add the product to cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cart"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<CartItem> AddProductToCart(Product product, Cart cart, int quantity)
        {
            CartItem cartItem = new CartItem()
            {
                Cart = cart,
                Product = product,
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = quantity
            };
            cart.Quantity += quantity;
            cart.Price += product.Price * quantity;


            await _product.UpdateProduct(product);
            await _cart.UpdateCart(cart);
            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return cartItem;
        }


        /// <summary>
        /// Get the cart items using user's email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public async Task<List<CartItem>> GetCartItems(string userEmail)
        {
            var cartItem = await _context.CartItems.Where(x => x.Cart.UserEmail == userEmail)
                .Include(x => x.Product)
                .Include(x => x.Cart)
                .ToListAsync();
            return cartItem;

        }

        /// <summary>
        /// Get cart item by product id and cart id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cartId"></param>
        /// <returns></returns>

        public async Task<CartItem> GetCartItem(int productId, int cartId)
        {
            var cartItem = await _context.CartItems.Where(x => x.ProductId == productId && x.CartId == cartId)
                .Include(x => x.Product)
                .Include(x => x.Cart)
                .FirstOrDefaultAsync();
            return cartItem;

        }


        /// <summary>
        /// remove product from cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        public async Task RemoveProductFromCart(Product product, Cart cart)
        {
            CartItem removedCartItem = _context.CartItems
                .Where(x => x.CartId == cart.Id && x.ProductId == product.Id)
                .FirstOrDefault();

            cart.Quantity -= removedCartItem.Quantity;
            cart.Price -= product.Price * removedCartItem.Quantity;
            product.Quantity += removedCartItem.Quantity;
            await _product.UpdateProduct(product);
            await _cart.UpdateCart(cart);
            _context.Entry(removedCartItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }


        /// <summary>
        /// Update the cart item
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            CartItem updatedCartItem = _context.CartItems
                .Where(x => x.CartId == cartItem.CartId && x.ProductId == cartItem.ProductId)
                .FirstOrDefault();

            updatedCartItem = cartItem;

            _context.Entry(updatedCartItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedCartItem;
        }

        /// <summary>
        /// Update the carts quantity and price
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cart"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<CartItem> UpdateCartQuantityAndPrice(Product product, Cart cart, int quantity)
        {
            var cartItem = await _context.CartItems.Where(x => x.ProductId == product.Id && x.CartId == cart.Id)
                .Include(x => x.Product)
                .Include(x => x.Cart)
                .FirstOrDefaultAsync();
            if (cartItem.Quantity > quantity && product.Quantity >= quantity)
            {
                cart.Quantity -= cartItem.Quantity - quantity;
                cart.Price -= product.Price * (cartItem.Quantity - quantity);
                cartItem.Quantity = quantity;
                product.Quantity += cartItem.Quantity - quantity;
            }
            if (cartItem.Quantity < quantity && product.Quantity >= quantity)
            {
                cart.Quantity += quantity - cartItem.Quantity;
                cart.Price += product.Price * (quantity - cartItem.Quantity);
                cartItem.Quantity = quantity;
                product.Quantity -= quantity - cartItem.Quantity;

            }
            await _product.UpdateProduct(product);
            await _cart.UpdateCart(cart);
            await UpdateCartItem(cartItem);

            return cartItem;

        }
    }
}
