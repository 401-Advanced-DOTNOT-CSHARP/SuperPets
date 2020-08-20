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
    public class CartItemService : ICartItem
    {
        private readonly StoreDbContext _context;

        public CartItemService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<CartItem> AddProductToCart(Product product, Cart cart)
        {
            CartItem cartItem = new CartItem()
            {
                Cart = cart,
                Product = product,
                CartId = cart.Id,
                ProductId = product.Id
            };
            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public Task<CartItem> GetCartItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveProductFromCart(Product product, Cart cart)
        {
            CartItem removedCartItem = _context.CartItems
                .Where(x => x.CartId == cart.Id && x.ProductId == product.Id)
                .FirstOrDefault();

            _context.Entry(removedCartItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

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
    }
}
