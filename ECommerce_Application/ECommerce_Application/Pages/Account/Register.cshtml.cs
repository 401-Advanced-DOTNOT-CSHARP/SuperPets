using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce_Application.Controllers;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Account
{
    /// <summary>
    /// References the page
    /// </summary>
    public class RegisterModel : PageModel
    {
        private UserManager<Customer> _usermanager;
        private readonly SignInManager<Customer> _signInManager;
        private IEmailSender _sender;
        private readonly ICart _cart;

        public RegisterModel(UserManager<Customer> userManager, SignInManager<Customer> signInManager, IEmailSender sender, ICart cart)
        {
            _usermanager = userManager;
            _signInManager = signInManager;
            _sender = sender;
            _cart = cart;
        }
        [BindProperty]
        public RegisterViewModel Registration { get; set; }
        public void OnGet()
        {

        }

        /// <summary>
        /// On post register the user, then send the user an email
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            Customer customer = new Customer()
            {
                Email = Registration.Email,
                FirstName = Registration.FirstName,
                FullName = Registration.FirstName + " " + Registration.LastName,
                LastName = Registration.LastName,
                UserName = Registration.Email,
                Address = Registration.Address,
                City = Registration.City,
                State = Registration.State,
                ZipCode = Registration.ZipCode
                
            };


            // Send registration confirmation to new user
            string subject = "Thanks for signing up with Super Pets!";
            string htmlMessage = $"<h1>Thank you {customer.FirstName}!</h1>";



            var result = await _usermanager.CreateAsync(customer, Registration.Password);
            if (result.Succeeded)
            {
                Claim fullName = new Claim("FullName", customer.FullName);
                Claim firstName = new Claim("FirstName", customer.FirstName);
                Claim lastName = new Claim("LastName", customer.LastName);
                Claim address = new Claim("Address", customer.Address);
                Claim city = new Claim("City", customer.City);
                Claim state = new Claim("State", customer.State);
                Claim zip = new Claim("Zip", customer.ZipCode);


                await _usermanager.AddClaimAsync(customer, fullName);
                await _usermanager.AddClaimAsync(customer, firstName);
                await _usermanager.AddClaimAsync(customer, lastName);
                await _usermanager.AddClaimAsync(customer, address);
                await _usermanager.AddClaimAsync(customer, city);
                await _usermanager.AddClaimAsync(customer, state);
                await _usermanager.AddClaimAsync(customer, zip);







                await _signInManager.SignInAsync(customer, isPersistent: false);
                await _sender.SendEmailAsync(customer.Email, subject, htmlMessage);
                Cart cart = new Cart()
                {
                    UserEmail = customer.Email,
                    Date = DateTime.Now
                };
                await _cart.CreateCart(cart);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Page();
            }            

            

        }

        /// <summary>
        /// Register view model requires the user to have set information.
        /// </summary>
        public class RegisterViewModel
        {
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Password's don't match")]
            public string ConfirmPassword { get; set; }
            [Display(Name = "First Name")]

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
        }
    }
}