using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface IProduct
    {

        List<Product> GetProducts();
    }
}
