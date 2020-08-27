using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Account
{
    public class UpdateInformationModel : PageModel
    {

        private readonly SignInManager<Customer> _signInManager;
        private readonly IPasswordHasher<Customer> _passwordHasher;
        private UserManager<Customer> _usermanager;



        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public bool Failed { get; set; }


        [BindProperty]
        public bool Succeeded { get; set; }

        public UpdateInformationModel(UserManager<Customer> userManger, SignInManager<Customer> signInManager, IPasswordHasher<Customer> passwordHasher)
        {
            _usermanager = userManger;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }




        /// <summary>
        /// Get the users information and return the page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGet()
        {
            Customer = await _usermanager.GetUserAsync(User);
            if (Customer == null)
            {
                return NotFound(
                    $"Unable to load user with ID '{_usermanager.GetUserId(User)}'.");
            }

            return Page();
        }

        /// <summary>
        /// Update the users information
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {

            Customer.FullName = Customer.FirstName + " " + Customer.LastName;
            var customer = await _usermanager.FindByEmailAsync(User.Identity.Name);




            if (customer != null)
            {
                customer.FirstName = Customer.FirstName;
                customer.LastName = Customer.LastName;
                customer.FullName = Customer.FullName;
                customer.Address = Customer.Address;
                customer.City = Customer.City;
                customer.State = Customer.State;
                customer.ZipCode = Customer.ZipCode;

                /*                customer.PasswordHash = _passwordHasher.HashPassword(customer, Customer.PasswordHash);
                */

            }


            var result = await _usermanager.UpdateAsync(customer);

            if (result.Succeeded)
            {


                var currentClaims = await _usermanager.GetClaimsAsync(customer);


                await _usermanager.RemoveClaimsAsync(customer, currentClaims);

                List<Claim> claims = new List<Claim>();


                claims.Add(new Claim("FullName", customer.FullName));
                claims.Add(new Claim("FirstName", customer.FirstName));
                claims.Add(new Claim("LastName", customer.LastName));
                claims.Add(new Claim("Address", customer.Address));
                claims.Add(new Claim("City", customer.City));
                claims.Add(new Claim("State", customer.State));
                claims.Add(new Claim("Zip", customer.ZipCode));


                var addClaimsResult = await _usermanager.AddClaimsAsync(customer, claims);


                if (addClaimsResult.Succeeded)
                {
                     _signInManager.RefreshSignInAsync(customer).Wait();

                    Succeeded = true;
                    Failed = true;
                    return RedirectToPage("/Account/Index");
                }

            }

            return Page();

        }




    }
}
