using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    /// <summary>
    /// Cart item class to specify the specific product
    /// </summary>
    public class CartItem
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }


    }
}
