using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Account
{
    /// <summary>
    /// References the page
    /// </summary>
    public class LogoutModel : PageModel
    {
        private SignInManager<Customer> _signInManager;

        public LogoutModel(SignInManager<Customer> signIn)
        {
            _signInManager = signIn;
        }

        public void OnGet()
        {

        }

        /// <summary>
        /// Redirect the user to home on logging out
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
