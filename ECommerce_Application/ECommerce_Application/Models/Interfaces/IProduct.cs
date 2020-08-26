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
        /// <summary>
        /// Get the products
        /// </summary>
        /// <returns></returns>
        public Task<List<Product>> GetProducts();

        /// <summary>
        /// Get a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Product> GetProduct(int id);

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Task<Product> UpdateProduct(Product product);

        /// <summary>
        /// Create the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Task<Product> CreateProduct(Product product);

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteProduct(int id);

    }
}
