using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface ICartItem
    {
        /// <summary>
        /// Get the cart items
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public Task<List<CartItem>> GetCartItems(string userEmail);

        /// <summary>
        /// Update the cart items
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        public Task<CartItem> UpdateCartItem(CartItem cartItem);

        /// <summary>
        /// Add the product to cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cart"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Task<CartItem> AddProductToCart(Product product, Cart cart, int quantity);

        /// <summary>
        /// Remove the product from the cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Task RemoveProductFromCart(Product product, Cart cart);

        /// <summary>
        /// Get the cart item
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public Task<CartItem> GetCartItem(int productId, int cartId);

        /// <summary>
        /// Update the quantity and price of product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cart"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Task<CartItem> UpdateCartQuantityAndPrice(Product product, Cart cart, int quantity);
    }
}
