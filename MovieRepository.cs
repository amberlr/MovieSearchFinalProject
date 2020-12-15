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
        private static readonly string _apiKey = System.IO.File.ReadAllText("api.txt");

        public IEnumerable<MovieModel> GetMovies(string userInput)
        {
            var client = new RestClient($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={ userInput }&page=1&r=json%22");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", _apiKey);
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            var movies = JObject.Parse(response.Content).GetValue("Search");

            var list = new List<MovieModel>();

            foreach (var mov in movies)
            //mov represents:    while movie represents:  
            {
                var movie = new MovieModel();
                movie.Title = (string)mov["Title"];

                //if(mov["Year"].ToString().Contains("-"))
                //{
                //    //movie.Year = int.Parse(mov["Year"].ToString().Substring(0, 3));
                //}
                //else
                //{
                //    movie.Year = (int)mov["Year"];

                //}
                movie.Year = (string)mov["Year"];
                movie.Poster = (string)mov["Poster"];
                movie.imdbID = (string)mov["imdbID"]; //has to be same as the json 

                list.Add(movie); //add the values to movie
            }
            return list;
        }

        //public MovieModel GetMovie(MovieModel movie) //do I need to do IEnumerable again since I want to return title, year, poster and add to list?
        //{
        //    //do I need to do the below again? it doesn't like response.content, but I don't know if that means I need to include api data again as well

        //    //var viewOneMovie = JObject.Parse(response.content).GetValue("View");


        //    //foreach (var viewMov in viewList)
        //    //{
        //    //    var mov = new MovieModel();
        //    //    mov.Title = (string)viewMov["Title"];
        //    //    mov.Year = (string)viewMov["Year"];
        //    //    mov.Poster = (string)viewMov["Poster"];
        //    //    viewList.Add(mov);
        //    //}
        //    //return viewList;

        //}
    }
}
