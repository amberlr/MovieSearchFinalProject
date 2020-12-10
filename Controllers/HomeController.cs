using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieDatabaseProject.Models;

namespace MovieDatabaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //private readonly IMovieRepository repo;

        //public HomeController(IMovieRepository repo)
        //{
        //    this.repo = repo;
        //}

        public IActionResult Index()
        {
            var movie = new MovieModel();
            return View(movie);
        }

        public IActionResult Search(MovieModel movie)
        {
            var repo = new MovieRepository();
            var movies = repo.GetMovies(movie.Title);

            return View(movies);

        }
        public IActionResult ViewMovie(string movieTitle)
        {
            var repo = new MovieRepository();
            //var viewMov = repo.GetMovie(viewMovie);
            var viewMov = repo.GetMovies(movieTitle);
            return View(viewMov);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
