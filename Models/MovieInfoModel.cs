using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseProject.Models
{
    public class MovieInfoModel
    {
        public MovieInfoModel()
        {

        }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Length { get; set; }
        public string Rating { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string imdbID { get; set; }
    }
}
