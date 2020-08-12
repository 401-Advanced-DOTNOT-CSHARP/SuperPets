using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.ViewModels
{
    public class ProductsViewModel : CerealDTO
    {
        public List<CerealDTO> Products;
        public int Id { get; set; }
    }
}
