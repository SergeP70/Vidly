using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Get: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        // Get: Movies/Details/1
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // Get: Movies/Edit
        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var viewModel = new MovieFormViewModel();


            if (movie == null)
            {
                viewModel.Genres = _context.Genres.ToList();
            }
            else 
            {
                viewModel.Movie = movie;
                viewModel.Genres = _context.Genres.ToList();
          
            }

            return View("MovieForm", viewModel);
        }

        // Post: Movies/Save
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.DateAdded = DateTime.Now;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.Stock = movie.Stock;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

    }
}