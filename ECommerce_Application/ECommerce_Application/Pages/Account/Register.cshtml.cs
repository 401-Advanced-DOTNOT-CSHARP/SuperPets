using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public RegisterModel(UserManager<Customer> userManager)
        {
            _usermanager = userManager;
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
                LastName = Registration.LastName,
                UserName = Registration.Email
            };
            if(Registration.Password == Registration.ConfirmPassword)
            {
                await _usermanager.CreateAsync(customer, Registration.Password);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Page();
            }

        }

        public class RegisterViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
        }
    }
}