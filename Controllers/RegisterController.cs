using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieDatabaseProject.Models;
using System.Net;
using System.Net.Mail;

namespace MovieDatabaseProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterRepository repo;

        public RegisterController(IRegisterRepository repo)
        {
            this.repo = repo;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Email()
        {
            return View();
        }
        public IActionResult RegisterUser() //not sure
        {
            var user = repo.AssignUser();
            return View(user);
        }
        public IActionResult RegisterUserToDatabase(RegisterModel registerUser)
        {
            repo.RegisterUser(registerUser);

            return RedirectToAction("Email");
        }
    }
}
