using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface ICart
    {
        /// <summary>
        /// Get the cart
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<Cart> GetCart(string email);

        /// <summary>
        /// Update the cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Task<Cart> UpdateCart(Cart cart);

        /// <summary>
        /// Create the cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Task<Cart> CreateCart(Cart cart);

        /// <summary>
        /// Delete the cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteCart(int id);
    }
}
