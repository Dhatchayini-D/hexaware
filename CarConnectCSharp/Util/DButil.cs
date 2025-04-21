using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnectCSharp.Util
{
    class DButil
    {
        public static SqlConnection GetDBConn()
        {
            string connectionString = "Server=DHATCHAYINI;Database=CarConnect;Integrated Security=True;TrustServerCertificate=True";

            SqlConnection connection = null!;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine(" Database connection established successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }
            return connection;
        }
    }
}

