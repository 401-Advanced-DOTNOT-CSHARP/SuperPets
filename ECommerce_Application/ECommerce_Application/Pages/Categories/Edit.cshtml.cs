using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce_Application.Data;
using ECommerce_Application.Models;

namespace ECommerce_Application.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ECommerce_Application.Data.StoreDbContext _context;

        public EditModel(ECommerce_Application.Data.StoreDbContext context)
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
           ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id");
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(CartItem.CartId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.CartId == id);
        }


    }
}
