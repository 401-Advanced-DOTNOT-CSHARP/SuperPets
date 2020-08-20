using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface ICart
    {
        public Task<Cart> GetCart(string email);
        public Task<Cart> UpdateCart(Cart cart);
        public Task<Cart> CreateCart(Cart cart);
        public Task DeleteCart(int id);
    }
}
