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
    public class IndexModel : PageModel
    {
        private readonly ECommerce_Application.Data.StoreDbContext _context;

        public IndexModel(ECommerce_Application.Data.StoreDbContext context)
        {
            _context = context;
        }

        public IList<CartItem> CartItem { get;set; }

        public async Task OnGetAsync()
        {
            CartItem = await _context.CartItems
                .Include(c => c.Cart)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
