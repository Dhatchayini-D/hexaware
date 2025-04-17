using System;
using System.Data;
using System.Data.SqlClient;

namespace CareerHub.Util
{
    public static class DBUtil
    {
        // Simplified method to get the connection string directly (hardcoded)
        public static SqlConnection GetConnection()
        {
            // Use a hardcoded connection string
            string connectionString = "Server=DHATCHAYINI;Database=CareerHubDB;Trusted_Connection=True;";

            // Return a new SqlConnection object with the connection string
            return new SqlConnection(connectionString);
        }
    }
}