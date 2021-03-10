using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApplication1.Data;
using MovieApplication1.Models;

namespace MovieApplication1.Controllers
{
    public class MoviesController : Controller
    {
        static List<Movie> movies = new List<Movie>()
        {new Movie(){ ID = Guid.NewGuid(), name = "Movie1", releaseYear = 2000 } };
        
        private readonly MovieApplication1Context _context;

        public MoviesController(MovieApplication1Context context)
        {
            _context = context;
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(movies);
        }

        // GET: Movies/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.ID = Guid.NewGuid();
                movies.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [FromForm] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var currentMovie = movies.FirstOrDefault(x => x.ID == id);
                currentMovie.name = movie.name;
                currentMovie.releaseYear = movie.releaseYear;

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movie = movies.Find(n => n.ID == id);
            movies.Remove(movie);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
