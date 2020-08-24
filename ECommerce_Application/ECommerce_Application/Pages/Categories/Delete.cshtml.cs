using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerce_Application.Data;
using ECommerce_Application.Models;

namespace ECommerce_Application.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ECommerce_Application.Data.StoreDbContext _context;

        public DeleteModel(ECommerce_Application.Data.StoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CartItem CartItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CartItem = await _context.CartItems
                .Include(c => c.Cart)
                .Include(c => c.Product).FirstOrDefaultAsync(m => m.CartId == id);

            if (CartItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CartItem = await _context.CartItems
                 .Include(c => c.Cart)
                .Include(c => c.Product).FirstOrDefaultAsync(m => m.CartId == id);

            if (CartItem != null)
            {
                _context.CartItems.Remove(CartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
