using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Data;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.Movies;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movies)
        {
            _db.Movies.Add(movies);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
                
        }
        public IActionResult Details(int id)
        {
            var model = _db.Movies.Find(id);
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Movies.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _db.Entry(movie).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
           return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var model = _db.Movies.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Movie model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [Route("Movie/MovieStore/{term?}")]
        public IActionResult MovieStore(string term="")
        {
            IEnumerable<Movie> model;
            if(string.IsNullOrEmpty(term))
            {
                model = _db.Movies;

            }
            else
            {
                model = _db.Movies.Where(b => b.Name.Contains(term));
            }
            ViewData["text"] = term;
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult More(int id)
        {
            var model = _db.Movies.Find(id);
            return View(model);
        }
    }
}