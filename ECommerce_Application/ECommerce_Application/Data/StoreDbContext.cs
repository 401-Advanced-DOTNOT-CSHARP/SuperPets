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
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Name = "Rampage",
                     Age = 2,
                      Breed = "Staffordshire Terrier",
                       Color = "Brindle",
                        Description = "Absolutely is an attention hog. He will chill and hang out with you all day and love life. He enjoys the outdoors " +
                        "from sunbathing in the backyard to going for long walks. Is very obedient and will let you clean his ears, brush "
                },
                new Games
                {
                    Id = 2,
                    Name = "The World of NonCraft"
                },
                new Games
                {
                    Id = 3,
                    Name = "City of Zeroes"
                });
        }

        public DbSet<Product> Products { get; set; }
    }
}
