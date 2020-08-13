using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce_Application.Controllers;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<Customer> _usermanager;
        private readonly SignInManager<Customer> _signInManager;

        public RegisterModel(UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            _usermanager = userManager;
            _signInManager = signInManager;
        }
        [BindProperty]
        public RegisterViewModel Registration { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            Customer customer = new Customer()
            {
                Email = Registration.Email,
                FirstName = Registration.FirstName,
                FullName = Registration.FirstName + " " + Registration.LastName,
                LastName = Registration.LastName,
                UserName = Registration.Email
            };
         
               var result = await _usermanager.CreateAsync(customer, Registration.Password);
            if (result.Succeeded)
            {
                Claim fullName = new Claim("FullName", customer.FullName);
                await _usermanager.AddClaimAsync(customer, fullName);
                await _signInManager.SignInAsync(customer, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Page();
            }            

            

        }

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
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}