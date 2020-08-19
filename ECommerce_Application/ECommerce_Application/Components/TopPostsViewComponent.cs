using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Application.Components
{
    [ViewComponent]
    public class TopPostsViewComponent : ViewComponent
    {
        private StoreDbContext _context;
        public TopPostsViewComponent(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {

            // do some logic to pull from the DB, the posts
            var posts = await _context.Posts.OrderByDescending(x => x.Id).Take(number).ToListAsync();

            return View(posts);
        }
    }
}
