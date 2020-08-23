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

            modelBuilder.Entity<CartItem>().HasKey(x => new { x.CartId, x.ProductId });

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
                    Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/Rampage",
                    Category = "Bully",
                    Quantity = 1,
                    IsFeature = true
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
                    Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/Snowball",
                    Category = "Poodles",
                    Quantity = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Whiskey",
                    Age = 7,
                    Breed = "Golden Doodle",
                    Color = "Golden",
                    Description = "Her thick hips won't stop her from dragging you across the concrete to catch a squirrel",
                    Price = 2000,
                    SuperPower = "Fly",
                    Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/Whiskey",
                    Category = "Poodles",
                    Quantity = 1
                },
                 new Product
                 {
                     Id = 4,
                     Name = "Rye",
                     Age = 6,
                     Breed = "Labradoodle",
                     Color = "black",
                     Description = "Fastest dog in the world. She's beat Usain Bolt... Twice. ",
                     Price = 9000,
                     SuperPower = "Super speed",
                     Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/rye.jpeg",
                     Category = "Poodles",
                     Quantity = 1
                 },
                  new Product
                  {
                      Id = 5,
                      Name = "Snowball",
                      Age = 3,
                      Breed = "Dog",
                      Color = "Brown and White",
                      Description = "Will knock anything on your desk onto the floor. Can also poop in toilet. ",
                      Price = 4000,
                      SuperPower = "Personality",
                      Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/backup.jpeg",
                      Category = "Poodles",
                      Quantity = 1
                  },
                   new Product
                   {
                       Id = 6,
                       Name = "Duke",
                       Age = 15,
                       Breed = "Dog",
                       Color = "Brown",
                       Description = "Speaks English... And a little Spanish. ",
                       Price = 9000,
                       SuperPower = "Speaking",
                       Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/Duke1.jpeg",
                       Category = "Bully",
                       Quantity = 1
                   },
                    new Product
                    {
                        Id = 7,
                        Name = "Josie",
                        Age = 99,
                        Breed = "Dog",
                        Color = "Grey",
                        Description = "Disrupts Zoom meetings. Can order Starbucks on occassion.",
                        Price = 6000,
                        SuperPower = "Ordering coffee",
                        Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/Josie",
                        Category = "Bully",
                        Quantity = 1
                    },
                     new Product
                     {
                         Id = 8,
                         Name = "Chubbs",
                         Age = 8,
                         Breed = "Dog",
                         Color = "Orangeish",
                         Description = "As if a dog wasn't enough, this guy comes with laser eyes. ",
                         Price = 1000,
                         SuperPower = "Laser Eyes",
                         Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/chubbs.jpeg",
                         Category = "Bully",
                         Quantity = 1
                     },
                      new Product
                      {
                          Id = 9,
                          Name = "Peanut",
                          Age = 15,
                          Breed = "Dog",
                          Color = "Orange and White",
                          Description = "An engineer who dabbles in explosives.",
                          Price = 5000,
                          SuperPower = "Super Genius",
                          Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/Peanut.jpeg",
                          Category = "Bully",
                          Quantity = 1
                      },
                       new Product
                       {
                           Id = 10,
                           Name = "Mani",
                           Age = 6,
                           Breed = "Pomeranian",
                           Color = "Black",
                           Description = "Makes bukoo money.",
                           Price = 1000,
                           SuperPower = "Can produce cash out of thin-air",
                           Image = "https://superpetpicturestorage.blob.core.windows.net/productimages/Mani",
                           Category = "Mixed",
                           Quantity = 1
                       }

                );

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


    }
}
