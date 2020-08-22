using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    /// <summary>
    /// comment
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string SuperPower { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public bool IsFeature { get; set; }


    }
}
