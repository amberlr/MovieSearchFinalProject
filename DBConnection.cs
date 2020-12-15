//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using System.Data.SqlClient;

//namespace MovieDatabaseProject
//{
//    public interface IDbConnection //decided to put the interface here too
//    {
//        public SqlConnection GetConnection { get; } //should I change this to GetConnection? I will do that for now
//    }
//    public class DbConnection : IDbConnection
//    {
//        IConfiguration Configuration;
//        public DbConnection(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }
//        public SqlConnection GetConnection
//        {
//            get {
//                var connectionString = Configuration.GetConnectionString("MoviesSQLDB");
//                return new SqlConnection(connectionString);
//            }
//        }
//    }
//}
