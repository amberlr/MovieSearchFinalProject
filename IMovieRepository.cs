using MovieDatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseProject
{
    public interface IMovieRepository
    {
        public IEnumerable<MovieModel> GetMovies(string userInput);
        //public MovieInfoModel GetMovieInfo(string movieTitle);
    }
}
