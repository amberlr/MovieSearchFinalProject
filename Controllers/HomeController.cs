using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            return View();
        }

        public IActionResult Search(string userInput)
        {
            var repo = new MovieRepository();
            var movies = repo.GetMovies(userInput);
            ViewData["userInput"] = userInput;

            return View(movies);

        }
        //public IActionResult ViewMovie(string movieTitle, string imdbID)
        //{
        //    var repo = new MovieRepository();
        //    var movies = repo.GetMovies(movieTitle); //I could technically put lines 39 thru 51 in its own method

        //    var movie = new MovieModel();

        //    foreach(var mov in movies)
        //    {
        //        if(mov.imdbID == imdbID)
        //        {
        //            movie = mov;
        //        }
        //    }
        //    return View(movie);
        //}

        public IActionResult ViewMovie(string id)
        {
            //dynamic movieInfo = new ExpandoObject();
            //movieInfo.MovieInfo = GetMovieInfo(id);
            //movieInfo.Actors = GetActors(id);
            //return View(movieInfo);



            var repo = new MovieRepository();
            var oneMovie = repo.GetMovieInfo(id);

            return View(oneMovie);
        }

        public IActionResult ViewActors(string id)
        {
            var repo = new MovieRepository();
            var actors = repo.GetActors(id);
            return View(actors);
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

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult ContactEmailSent()
        {
            return View();
        }

        //below is where I added ability to email via contact page
        public async Task<ActionResult> email(IFormCollection form)
        {
            var name = form["sname"];
            var email = form["semail"];
            var messages = form["smessage"];
            var phone = form["sphone"];
            var x = await SendEmail(name, email, messages, phone);
            if (x == "sent")
                ViewData["esent"] = "Your Message Has Been Sent"; //i made a new view.. so do I even need this now?
            return RedirectToAction("ContactEmailSent");
        }

        private static readonly string _emailKey = System.IO.File.ReadAllText("emailPass.txt");
        private async Task<string> SendEmail(string name, string email, string messages, string phone)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("ambertesttime@outlook.com")); // replace with receiver's email id //ok how do I make this look at what user types?
            message.From = new MailAddress("ambertesttime@outlook.com"); // replace with sender's email id     
            message.Subject = "Message From" + email;
            message.Body = "Name: " + name + "\nFrom: " + email + "\nPhone: " + phone + "\n" + messages;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "ambertesttime@outlook.com", // replace with sender's email id     
                    Password = _emailKey // replace with password //how do I hide password?
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return "sent";
            }
        }
    }
}
