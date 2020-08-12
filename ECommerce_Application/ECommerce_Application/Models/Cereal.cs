using ECommerce_Application.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    public class Cereal : Product
    {
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Calories { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Sodium { get; set; }
        public string Fiber { get; set; }
        public string Carbohydrates { get; set; }
        public string Sugar { get; set; }
        public string Potassium { get; set; }
        public string Vitamins { get; set; }
        public string Shelf { get; set; }
        public string Weight { get; set; }
        public string Cups { get; set; }
        public string Rating { get; set; }


    }
}
