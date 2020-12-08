using MovieDatabaseProject.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseProject
{
    public class MovieRepository : IMovieRepository
    {
        public IEnumerable<MovieModel> GetMovies()
        {
            string userInput = Console.ReadLine();
            //https://movie-database-imdb-alternative.p.rapidapi.com/?s=Avengers%20Endgame&page=1&r=json%22

            var client = new RestClient($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={ userInput }&page=1&r=json%22");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "8728f075a0msh30232edd24e8879p118906jsn346f28102e77");
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            var movies = JObject.Parse(response.Content).GetValue("Search");

            var list = new List<MovieModel>();

            foreach (var mov in movies)
                //mov represents:    while movie represents:  
            {
                var movie = new MovieModel();
                movie.Title = (string)mov["Title"];
                movie.Year = (int)mov["Year"];
                movie.Poster = (string)mov["Poster"];

                list.Add(movie); //add the values to movie
            }
            return list;
        }
    }
}
