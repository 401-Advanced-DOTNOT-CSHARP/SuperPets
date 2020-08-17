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

        public Task<List<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task<Product> UpdateProduct(Product product);
        public Task<Product> CreateProduct(Product product);
        public Task DeleteProduct(int id);

    }
}
