/*using ECommerce_Application.Data;
using ECommerce_Application.Models;
using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Services;
using ECommerce_Application.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using static ECommerce_Application.Program;

namespace TestingSprint1
{
    public class UnitTest1
    {
        /*
        [Fact]
        public void GetterSetter()
        {
            CerealDTO cerealDTO = new CerealDTO();

            cerealDTO.Name = "Code Fellows Multi Flavored Cups";
            cerealDTO.Manufacturer = "Bryants Blandish Cereal";

            Assert.Equal("Code Fellows Multi Flavored Cups", cerealDTO.Name);
            Assert.Equal("Bryants Blandish Cereal", cerealDTO.Manufacturer);

        }

        [Fact]
        public void GetterSetter2()
        {
            Product product = new Product();

            product.Name = "Code Fellows Multi Flavored Cups";
            product.Description = "Bryants Blandish Cereal";

            Assert.Equal("Code Fellows Multi Flavored Cups", product.Name);
            Assert.Equal("Bryants Blandish Cereal", product.Description);

        }

        [Fact]
        public async void CanCreateProductAndSaveToDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanCreateGameAndSaveToDatabase")
                .Options;
            using StoreDbContext context = new StoreDbContext(options);
            InventoryManagement service = new InventoryManagement(context);
            Product dog = new Product() {
                Name = "Rampage2",
                Age = 20,
                Breed = "American Bull Dog",
                Color = "Brindle",
                Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors " +
                        "from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ",
                Price = 200000,
                SuperPower = "Super Speed",
            };
            Assert.Equal(0, context.Products.CountAsync().Result);
            var result = await service.CreateProduct(dog);
            var actual = context.Products.FindAsync(result.Id).Result;
            Assert.Equal(1, context.Products.CountAsync().Result);
            // Assert.IsType<Games>(actual);
            Assert.Equal(1, actual.Id);
            Assert.Equal("Rampage2", actual.Name);

        }

        [Fact]
        public async void CanUpdateProductAndSaveToDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanUpdateProductAndSaveToDatabase")
                .Options;
            using StoreDbContext context = new StoreDbContext(options);
            InventoryManagement service = new InventoryManagement(context);
            Product dog = new Product()
            {
                Name = "Rampage2",
                Age = 20,
                Breed = "American Bull Dog",
                Color = "Brindle",
                Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors " +
                        "from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ",
                Price = 200000,
                SuperPower = "Super Speed",
            };
            Assert.Equal(0, context.Products.CountAsync().Result);
            var result = await service.CreateProduct(dog);
            Product updatedDog = new Product()
            {
                Name = "Rampage5000",
                Age = 20,
                Breed = "American Bull Dog",
                Color = "Brindle",
                Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors " +
            "from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ",
                Price = 200000,
                SuperPower = "Super Speed",
            };
            var updated = service.UpdateProduct(updatedDog);
            var actual = context.Products.FindAsync(result.Id).Result;
            Assert.Equal(1, context.Products.CountAsync().Result);
            // Assert.IsType<Games>(actual);
            Assert.Equal(1, actual.Id);
            Assert.Equal("Rampage2", actual.Name);

        }
        [Fact]
        public async void CanDeleteProductFromDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanDeleteProductFromDatabase")
                .Options;
            using StoreDbContext context = new StoreDbContext(options);
            InventoryManagement service = new InventoryManagement(context);
            Product dog = new Product()
            {
                Name = "Rampage2",
                Age = 20,
                Breed = "American Bull Dog",
                Color = "Brindle",
                Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors " +
                        "from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ",
                Price = 200000,
                SuperPower = "Super Speed",
            };
            Assert.Equal(0, context.Products.CountAsync().Result);
            var result = await service.CreateProduct(dog);
            var actual = context.Products.FindAsync(result.Id).Result;
            Assert.Equal(1, context.Products.CountAsync().Result);
            var delete = service.DeleteProduct(result.Id);
            Assert.Equal(0, context.Products.CountAsync().Result);

        }

        [Fact]
        public async void CanGetProductFromDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("CanGetProductFromDatabase")
                .Options;
            using StoreDbContext context = new StoreDbContext(options);
            InventoryManagement service = new InventoryManagement(context);
            Product dog = new Product()
            {
                Name = "Rampage2",
                Age = 20,
                Breed = "American Bull Dog",
                Color = "Brindle",
                Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors " +
                        "from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ",
                Price = 200000,
                SuperPower = "Super Speed",
            };
            Assert.Equal(0, context.Products.CountAsync().Result);
            var result = await service.CreateProduct(dog);
            var actual = service.GetProduct(result.Id).Result;
            Assert.Equal(1, context.Products.CountAsync().Result);
            // Assert.IsType<Games>(actual);
            Assert.Equal(1, actual.Id);
            Assert.Equal("Rampage2", actual.Name);

        }
        */



