using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Account
{
    /// <summary>
    /// References the Page
    /// </summary>
    public class LoginModel : PageModel
    {
        private SignInManager<Customer> _signInManager;

        public LoginModel(SignInManager<Customer> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public LoginViewModel Login { get; set; }
        public void OnGet()
        {

        }

        /// <summary>
        /// Post the login information
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Login.Email, Login.Password, false, false);

                if (result.Succeeded)
                {
                    return new RedirectToPageResult("/");
                }
            }

            ModelState.AddModelError("", "Invalid Username or Password");
            return Page();

        }


        /// <summary>
        /// The login view model contains our required properties in order to join
        /// </summary>
        public class LoginViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
    }
}