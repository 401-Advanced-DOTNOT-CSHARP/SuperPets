using ECommerce_Application.Models;
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
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            //Just want to add some changes so we can see if the database updates//
        }

    }
}
