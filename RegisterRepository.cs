using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MovieDatabaseProject.Models;

namespace MovieDatabaseProject
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly IDbConnection _conn;

        public RegisterRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<RegisterModel> GetAllUsers()
        {
            return _conn.Query<RegisterModel>("SELECT * FROM logininfo;");
        }
        public void RegisterUser(RegisterModel registerUser)
        {
            _conn.Execute("INSERT INTO logininfo (EMAILID, PASSWORD) VALUES (@emailID, @password);",
                new
                {
                    emailID = registerUser.EmailID,
                    password = registerUser.Password
                });
        }
        //not sure:
        public RegisterModel AssignUser()
        {
            var newUser = new RegisterModel();
            return newUser;
        }
    }
}
