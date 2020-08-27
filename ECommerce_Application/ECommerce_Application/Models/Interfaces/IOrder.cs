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
        /// <summary>
        /// Get the order for the user
        /// </summary>
        /// <param name="id">Id of the order to be retrieved</param>
        /// <returns>Returns the requested Order</returns>
        Task<Order> GetOrder(int id);

        /// <summary>
        /// Grabs a list of all orders by the user matching the user email sorts it by date
        /// </summary>
        /// <param name="userEmail">The users email of orders you wish to retireve</param>
        /// <returns>A List of Orders sorted by date</returns>
        Task<List<Order>> GetAllOrders(string userEmail);

    }
}
