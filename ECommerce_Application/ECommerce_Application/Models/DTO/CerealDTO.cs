using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.DTO
{
    public class CerealDTO
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Sodium { get; set; }
        public int Fiber { get; set; }
        public int Carbohydrates { get; set; }
        public int Sugar { get; set; }
        public int Potassium { get; set; }
        public int Vitamins { get; set; }
        public int Shelf { get; set; }
        public decimal Weight { get; set; }
        public decimal Cups { get; set; }
        public decimal Rating { get; set; }
    }
}
