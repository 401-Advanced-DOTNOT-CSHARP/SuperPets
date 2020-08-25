using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface ICartItem
    {
        public Task<List<CartItem>> GetCartItems(string userEmail);
        public Task<CartItem> UpdateCartItem(CartItem cartItem);
        public Task<CartItem> AddProductToCart(Product product, Cart cart, int quantity);
        public Task RemoveProductFromCart(Product product, Cart cart);
        public Task<CartItem> GetCartItem(int productId, int cartId);
        public Task<CartItem> UpdateCartQuantityAndPrice(Product product, Cart cart, int quantity);
    }
}
