using ECommerce_Application.Models;
using ECommerce_Application.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Name = "Rampage",
                    Age = 2,
                    Breed = "Staffordshire Terrier",
                    Color = "Brindle",
                    Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors " +
                        "from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush ",
                    Price = 200,
                    SuperPower = "Super Love",
                },
                new Product
                {
                    Id = 2,
                    Name = "Snowball",
                    Age = 4,
                    Breed = "Poodle",
                    Color = "White",
                    Description = "Loves ",
                    Price = 200,
                    SuperPower = "Super Love",

                },
                new Product
                {
                    Id = 3,
                    Name = "Whiskey",
                    Age = 7,
                    Breed = "Golden Doodle",
                    Color = "Golden",
                    Description = "Is a pro at Squirrel catching by flying into the trees to catch them",
                    Price = 2000,
                    SuperPower = "Fly",
                });
        }

        public DbSet<Product> Products { get; set; }
    }
}
