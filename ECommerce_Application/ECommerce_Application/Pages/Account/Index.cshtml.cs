

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerce_Application.Data;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ECommerce_Application.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<Customer> _signInManager;

        private UserManager<Customer> _usermanager;



        public IndexModel(UserManager<Customer> userManger, SignInManager<Customer> signInManager)
        {
            _usermanager = userManger;
            _signInManager = signInManager;
        }



        /// <summary>
        /// Get the users information and return the page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGet()
        {
            var user = await _usermanager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(
                    $"Unable to load user with ID '{_usermanager.GetUserId(User)}'.");
            }

            return Page();
        }








    }
}


