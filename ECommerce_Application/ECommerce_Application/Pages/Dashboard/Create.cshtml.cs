using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerce_Application.Data;
using ECommerce_Application.Models;
using Microsoft.AspNetCore.Authorization;
using ECommerce_Application.Models.Interfaces;

namespace ECommerce_Application.Pages.Dashboard
{
    /// <summary>
    /// Only admin can edit
    /// </summary>
    [Authorize(Policy = "Administrator")]

    public class CreateModel : PageModel
    {
        private readonly StoreDbContext _context;
        private readonly IImage _image;

        [BindProperty]
        public string Image { get; set; }
        [BindProperty]
        public List<string> Blobs { get; set; }


        public CreateModel(StoreDbContext context, IImage image)
        {
            _context = context;
            _image = image;
        }

        public async Task<IActionResult> OnGet()
        {
            Blobs = await _image.GetAllBlobs();
            return Page();
        }

        /// <summary>
        /// Property to bind our create to the product
        /// </summary>

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
