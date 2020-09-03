using ECommerce_Application.Data;
using ECommerce_Application.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Services
{
    /// <summary>
    /// Referencing the Interface Order
    /// </summary>
    public class OrderService : IOrder
    {
        private readonly StoreDbContext _context;

        public OrderService(StoreDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Create the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> CreateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return order;
        }



        /// <summary>
        /// Get the order by the user's email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public async Task<Order> GetOrder(string userEmail)
        {
            Order order = await _context.Orders.Where(x => x.UserEmail == userEmail)
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync();

            return order;
        }
        /// <summary>
        /// Grabs a list of all orders by the user matching the user email sorts it by date
        /// </summary>
        /// <param name="userEmail">The users email of orders you wish to retireve</param>
        /// <returns>A List of Orders sorted by date</returns>
        public async Task<List<Order>> GetAllOrders(string userEmail)
        {
            List<Order> order = await _context.Orders.Where(x => x.UserEmail == userEmail)
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

            return order;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> order = await _context.Orders
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

            return order;
        }
        public async Task<Order> GetOrder(int id)
        {
            Order order = await _context.Orders.Where(x => x.Id == id)
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync();

            return order;
        }
    }
}
