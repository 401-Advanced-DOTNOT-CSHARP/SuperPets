using ECommerce_Application.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models
{
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Administrator, NormalizedName = ApplicationRoles.Administrator.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },

            };


        //method that creates/checks the roles
        //add the roles into the db directly



        public static void SeedData(IServiceProvider serviceProvider, UserManager<Customer> userManager, IConfiguration _config)
        {
            using (var dbContext = new UserDbContext(serviceProvider.GetRequiredService<DbContextOptions<UserDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                SeedUsers(userManager, _config);
            }
        }

        public static void AddRoles(UserDbContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        public static void SeedUsers(UserManager<Customer> userManager, IConfiguration _config)
        {
            if (userManager.FindByEmailAsync(_config["Administrator"]).Result == null)
            {
                Customer user = new Customer();
                user.UserName = _config["Administrator"];
                user.Email = user.UserName;
                user.FirstName = user.FirstName;
                user.LastName = user.LastName;
                user.FullName = user.FirstName + user.LastName;
                IdentityResult result = userManager.CreateAsync(user, _config["Password"]).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ApplicationRoles.Administrator);
                }
            }
        }
    }
}
