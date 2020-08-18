using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Data;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using ECommerce_Application.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce_Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<UserDbContext>(options =>
            {
                // Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("UserConnection"));
            });

            services.AddDbContext<StoreDbContext>(options =>
            {
                // Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<Customer, IdentityRole>()
                    .AddEntityFrameworkStores<UserDbContext>()
                    .AddDefaultTokenProviders();

            services.AddTransient<IProduct, InventoryManagement>();
            services.AddTransient<IImage, Blob>();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireRole(ApplicationRoles.Administrator));

           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
            RoleInitializer.SeedData(serviceProvider, userManager, Configuration);
            app.UseEndpoints(endpoints  =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
