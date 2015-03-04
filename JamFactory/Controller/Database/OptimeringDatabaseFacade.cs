using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JamFactory.Controller.Database {
    class OptimeringDatabaseFacade {
        //Database 20
        static SqlConnection dbconn;
        static string _connectionString = "Server=ealdb1.eal.local; User ID=ejl20_usr; Password=Baz1nga20; Database=EJL20_DB";

        private static void ConnectDB() {
            dbconn = new SqlConnection(_connectionString);
            dbconn.Open();
        }

        private static void CloseDB() {
            dbconn.Close();
        }

    }
}
