using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieDatabaseProject.Models;

namespace MovieDatabaseProject
{
    public interface IRegisterRepository
    {
        public IEnumerable<RegisterModel> GetAllUsers();
        public void RegisterUser(RegisterModel registerUser);
        //not sure if needed:
        public RegisterModel AssignUser();
    }
}
