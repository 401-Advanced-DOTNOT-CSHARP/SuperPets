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
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce_Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
            WebHostEnvironment = webHostEnvironment;
        }
        private string GetHerokuConnectionString(string connectionString)
        {
            // Get the connection string from the ENV variables
            // Modified to bring in connection string from secrets in Development
            string connectionUrl = WebHostEnvironment.IsDevelopment()
                ? Configuration["ConnectionStrings:" + connectionString]
                : Environment.GetEnvironmentVariable(connectionString);

            // parse the connection string
            var databaseUri = new Uri(connectionUrl);

            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<StoreDbContext>(options => options.UseNpgsql(GetHerokuConnectionString("STORE_DATABASE_URL_ENV")));
            services.AddDbContext<UserDbContext>(options => options.UseNpgsql(GetHerokuConnectionString("USER_DATABASE_URL_ENV")));

            services.AddIdentity<Customer, IdentityRole>()
                    .AddEntityFrameworkStores<UserDbContext>()
                    .AddDefaultTokenProviders();

            services.AddTransient<IProduct, InventoryManagement>();
            services.AddTransient<IImage, Blob>();
            services.AddTransient<IEmailSender, EmailSenderService>();
            services.AddTransient<ICart, CartService>();
            services.AddTransient<ICartItem, CartItemService>();
            services.AddTransient<IOrder, OrderService>();
            services.AddTransient<IPayment, PaymentService>();



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
            RoleInitializer.SeedData(serviceProvider, userManager, Configuration, env);
            app.UseEndpoints(endpoints  =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
