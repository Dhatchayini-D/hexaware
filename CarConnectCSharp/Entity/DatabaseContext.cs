using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnectCSharp.Entity
{
    class DatabaseContext
    {
        string connectionString = "Server=DHATCHAYINI;Database=CarConnect;Integrated Security=True;TrustServerCertificate=True";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
