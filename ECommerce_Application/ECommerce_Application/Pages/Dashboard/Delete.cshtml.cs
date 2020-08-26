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

    public class DeleteModel : PageModel
    {
        private readonly ECommerce_Application.Data.StoreDbContext _context;

        public DeleteModel(ECommerce_Application.Data.StoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        
        /// <summary>
        /// Get the property for deletion
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

        /// <summary>
        /// Update the product deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FindAsync(id);

            if (Product != null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
