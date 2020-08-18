using ECommerce_Application.Data;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Services
{
    public class InventoryManagement : IProduct
    {
        private readonly StoreDbContext _context;
        private readonly Blob _blobs;
        private readonly IConfiguration _config;


        public InventoryManagement(StoreDbContext context, Blob blobs, IConfiguration config)
        {
            _context = context;
            _blobs = blobs;
            _config = config;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            product.Image = _blobs.GetBlob(product.Name, _config["ImageContainer"]).ToString();
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            Product dog = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Entry(dog).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var dog = await _context.Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return dog;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> dogs = await _context.Products
                .ToListAsync();

            return dogs;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var dog = await _context.Products.FindAsync(product.Id);

            dog.Name = product.Name;
            dog.Price = product.Price;
            dog.SKU = product.SKU;
            dog.SuperPower = product.SuperPower;
            dog.Description = product.Description;
            dog.Color = product.Color;
            dog.Breed = product.Breed;
            dog.Age = product.Age;
            dog.Image = product.Image;


            _context.Entry(dog).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return dog;
        }
    }
}
