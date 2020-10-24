using System;
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
        // Get: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        // Get: Movies/Details/1
        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }


        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie {Id = 0, Name="Shrek"},
                new Movie {Id = 1, Name="Toy Story"},
                new Movie {Id = 2, Name="Inside Out"},
                new Movie {Id = 3, Name="The Incredibles"},
                new Movie {Id = 4,Name="Chicken Run"},
            };

        }

    }
}