using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Components
{
    public class MovieListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public MovieListViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _db.Movies.Take(4).ToListAsync();
            return View(model);
        }
    }
}
