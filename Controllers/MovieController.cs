using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieDatabaseProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository repo;

        public MovieController(IMovieRepository repo)
        {
            this.repo = repo;
        }

        //public IActionResult Index()
        //{
        //    var movie = repo.GetMovies();

        //    return View();
        //}
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://movie-database-imdb-alternative.p.rapidapi.com/?s=Avengers%20Endgame&page=1&r=json%22";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }
            }
            return View();
        }
    }
}

