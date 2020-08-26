using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface IPayment
    {
        /// <summary>
        /// Run the users information 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="cardName"></param>
        /// <param name="expiration"></param>
        /// <param name="cvc"></param>
        /// <returns></returns>
        Task<string> Run(string userEmail, string cardName, string expiration, string cvc);
    }
}
