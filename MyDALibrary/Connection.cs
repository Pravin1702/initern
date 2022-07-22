using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDALibrary
{
    //Singleton class
    class Connection
    {
        static Connection connection;
        public SqlConnection conn { get; set; }
        private Connection()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public static Connection GetConnection()
        {
            if (connection == null)
            {
                connection = new Connection();
            }
            return connection;

        }
    }
}