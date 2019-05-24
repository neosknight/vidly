using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        List<Movie> Movies = new List<Movie>()
        {
            new Movie { Id = 1, Name = "Matrix" },
            new Movie { Id = 2, Name = "Kill Bil" }
        };

        public ActionResult Index()
        {
            var viewModel = new MoviesViewModel { Movies = Movies };

            return View(viewModel);
        }

        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Kill Bill" };

            var customers = new List<Customer>()
            {
                new Customer { Name = "Luka" },
                new Customer { Name = "Sanja" }
            };

            var viewModel = new RandomMovieViewModel { Movie = movie, Customers = customers };

            return View(viewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("year={0}, month={1}", year, month));
        }
    }
}