using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerce_Application.Data;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce_Application.Pages.Dashboard
{
    /// <summary>
    /// Only admin can edit
    /// </summary>
    [Authorize(Policy = "Administrator")]

    public class DetailsModel : PageModel
    {
        private readonly ECommerce_Application.Data.StoreDbContext _context;

        public DetailsModel(ECommerce_Application.Data.StoreDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }


        /// <summary>
        /// Get the details upon request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
