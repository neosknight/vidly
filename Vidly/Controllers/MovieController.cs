﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new MoviesViewModel { Movies = movies };

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