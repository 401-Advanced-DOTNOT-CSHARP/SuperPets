using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Models;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_Application.Pages.Dashboard
{
    [Authorize(Policy = "Administrator")]


    public class PictureModel : PageModel
    {
        private IImage _image;
        private readonly IProduct _product;

        [BindProperty]
        public IFormFile Image { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public List<Product> Products { get; set; }

        public PictureModel(IImage image, IProduct product)
        {
            _image = image;
            _product = product;
        }
        public async Task<IActionResult> OnGet()

        {
            Products = await _product.GetProducts();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            string ext = Path.GetExtension(Image.FileName);

            if (Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    var bytes = stream.ToArray();
                    await _image.UploadImage(Name, bytes, Image.ContentType);
                }
            }

            return Page();

        }
    }
}