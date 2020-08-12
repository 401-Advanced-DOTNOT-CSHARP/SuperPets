using ECommerce_Application.Models;
using ECommerce_Application.Models.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Data
{
    public class UserDbContext : IdentityDbContext<Customer>
    {
        public DbSet<Product> Products { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            //This is remains empty
          }
}
}
