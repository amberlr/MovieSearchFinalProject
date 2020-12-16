using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabaseProject.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {

        }
        public int UserID { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
    }
}
