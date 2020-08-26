using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    /// <summary>
    /// Cart class that holds appropriate properties for a "cart"
    /// </summary>
    public class Cart 
    {

        public int Id { get; set; }
        public string UserEmail { get; set; }
        public decimal Price { get; set; }
        public int Quantity  { get; set; }
        public DateTime Date { get; set; }
        public List<CartItem> CartItems { get; set; }

    }
}
