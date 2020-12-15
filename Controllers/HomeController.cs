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

        public IActionResult Index()
        {
            //var movie = new MovieModel();
            return View();
        }

        public IActionResult Search(string userInput)
        {
            //var mov = new MovieModel();
            //mov.Title = movieName;
            //var repo = new MovieRepository();
            //var movies = repo.GetMovies(movieName);

            //return View(movies);


            var repo = new MovieRepository();
            var movies = repo.GetMovies(userInput);
            ViewData["userInput"] = userInput;

            return View(movies);

        }
        public IActionResult ViewMovie(string movieTitle, string imdbID)
        {
            var repo = new MovieRepository();
            var movies = repo.GetMovies(movieTitle); //I could technically put lines 39 thru 51 in its own method

            var movie = new MovieModel();

            foreach(var mov in movies)
            {
                if(mov.imdbID == imdbID)
                {
                    movie = mov;
                }
            }
            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
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
