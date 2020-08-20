using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    public class Cart 
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public decimal Price { get; set; }
        public int Quantity  { get; set; }
        public List<Product> Products { get; set; }

    }
}
