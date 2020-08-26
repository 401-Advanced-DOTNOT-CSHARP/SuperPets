using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface IOrder
    {
        /// <summary>
        /// Create the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> CreateOrder(Order order);

        /// <summary>
        /// Get the order for the user
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        Task<Order> GetOrder(string userEmail);
    }
}
