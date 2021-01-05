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

        private static readonly string _api2Key = System.IO.File.ReadAllText("api2.txt");

        public IEnumerable<MovieModel> GetMovies(string userInput)
        {
            var client = new RestClient($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={ userInput }&page=1&r=json%22");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", _apiKey);
            request.AddHeader("x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            var movies = JObject.Parse(response.Content).GetValue("Search");

            var list = new List<MovieModel>();

            if(movies == null)
            {
                return null;
            }

            foreach (var mov in movies)
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

                list.Add(movie);
            }
            return list;
        }

        public MovieInfoModel GetMovieInfo(string id)
        {
            var client = new RestClient($"https://imdb-internet-movie-database-unofficial.p.rapidapi.com/film/{ id }");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", _api2Key);
            request.AddHeader("x-rapidapi-host", "imdb-internet-movie-database-unofficial.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            var movie = JObject.Parse(response.Content);

            var mov = new MovieInfoModel();
            mov.Title = (string)movie["title"];
            mov.Year = (string)movie["year"];
            mov.Length = (string)movie["length"];
            mov.Rating = (string)movie["rating"];
            mov.Poster = (string)movie["poster"];
            mov.Plot = (string)movie["plot"];
            mov.imdbID = (string)movie["id"];
            mov.Trailer = movie["trailer"];

            var trailer = JObject.Parse(response.Content).GetValue("trailer");
            mov.Link = (string)trailer["link"];

            if(mov.Link == null) //trying to get this to work in view
            {
                return null;
            }
            return mov;
        }

        public IEnumerable<ActorModel> GetActors(string id)
        {
            var client = new RestClient($"https://imdb-internet-movie-database-unofficial.p.rapidapi.com/film/{ id }");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", _api2Key);
            request.AddHeader("x-rapidapi-host", "imdb-internet-movie-database-unofficial.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            var actors = JObject.Parse(response.Content).GetValue("cast");

            var actorList = new List<ActorModel>();

            foreach (var act in actors)
            {
                var actor = new ActorModel();
                actor.Actor = (string)act["actor"];
                actor.Character = (string)act["character"];

                actorList.Add(actor);
            }
            return actorList;
        }
    }
}
