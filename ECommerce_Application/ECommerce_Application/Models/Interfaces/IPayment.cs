using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface IPayment
    {
        Task<string> Run(string userEmail);
    }
}
