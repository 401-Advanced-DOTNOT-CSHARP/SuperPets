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
  [Authorize(Policy = "Administrator")]

    public class IndexModel : PageModel
    {
        private readonly ECommerce_Application.Data.StoreDbContext _context;

        public IndexModel(ECommerce_Application.Data.StoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}
