using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface IOrder
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrder(string userEmail);
    }
}
