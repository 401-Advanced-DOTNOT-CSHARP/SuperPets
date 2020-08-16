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
                    Description = "Her thick hips won't stop her from dragging you across the concrete to catch a squirrel",
                    Price = 2000,
                    SuperPower = "Fly",
                },
                 new Product
                 {
                     Id = 4,
                     Name = "Rye",
                     Age = 6,
                     Breed = "Labradoodle",
                     Color = "black",
                     Description = "Fastest dog in the world. She's beat Usain Bolt... Twice. ",
                     Price = 90000000,
                     SuperPower = "Super speed",

                 },
                  new Product
                  {
                      Id = 5,
                      Name = "Snowball",
                      Age = 3,
                      Breed = "Siamese Cat",
                      Color = "Black and White",
                      Description = "Will knock anything on your desk onto the floor. Can also poop in toilet. ",
                      Price = 40000,
                      SuperPower = "Personality",

                  },
                   new Product
                   {
                       Id = 6,
                       Name = "Duke",
                       Age = 15,
                       Breed = "Bear",
                       Color = "Brown",
                       Description = "Speaks English... And a little Spanish. ",
                       Price = 9000,
                       SuperPower = "Speaking",

                   },
                    new Product
                    {
                        Id = 7,
                        Name = "Josie",
                        Age = 99,
                        Breed = "Tabbie Cat (unsure)",
                        Color = "Grey",
                        Description = "Disrupts Zoom meetings. Can order Starbucks on occassion.",
                        Price = 6000000,
                        SuperPower = "Ordering coffee",

                    },
                     new Product
                     {
                         Id = 8,
                         Name = "Chubbs",
                         Age = 8,
                         Breed = "Lion",
                         Color = "Orangeish",
                         Description = "As if a lion wasn't enough, this guy comes with laser eyes. ",
                         Price = 1000000,
                         SuperPower = "Laser Eyes",

                     },
                      new Product
                      {
                          Id = 9,
                          Name = "Peanut",
                          Age = 15,
                          Breed = "Hamster",
                          Color = "Orange and White",
                          Description = "An engineer who dabbles in explosives.",
                          Price = 500000,
                          SuperPower = "Super Genius",

                      },
                       new Product
                       {
                           Id = 10,
                           Name = "Mani",
                           Age = 6,
                           Breed = "Pomeranian",
                           Color = "Black",
                           Description = "Makes bukoo money.",
                           Price = 1000000000000,
                           SuperPower = "Can produce cash out of thin-air",

                       }



                );
        }

        public DbSet<Product> Products { get; set; }
    }
}
