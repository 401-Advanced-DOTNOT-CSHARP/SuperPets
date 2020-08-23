using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface ICartItem
    {
        public Task<CartItem> GetCartItem(int id);
        public Task<CartItem> UpdateCartItem(CartItem cartItem);
        public Task<CartItem> AddProductToCart(Product product, Cart cart, int quantity);
        public Task RemoveProductFromCart(Product product, Cart cart);
    }
}
