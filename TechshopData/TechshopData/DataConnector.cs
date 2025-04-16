
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace TechshopData.data
{
    public class DataConnector
    {
        private readonly string _connectionString = @"Data Source=DHATCHAYINI;Initial Catalog=tech;Integrated Security=True;";
       
        private SqlConnection _connection;

        public DataConnector()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public DataConnector(string connectionString)
        {
            _connectionString = "Data Source=DHATCHAYINI;Initial Catalog=tech;Integrated Security=True;";
            _connection = new SqlConnection(_connectionString);
        }

        // Method to get the SqlConnection
        public SqlConnection GetConnection()
        {
            return _connection;
        }

        // Method to open the connection if closed
        public void OpenConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        // Method to close the connection (optional but useful)
        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        // Get all products from the database
        internal List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                OpenConnection();

                using (var command = new SqlCommand("SELECT * FROM products", _connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Description = reader.GetString(2),
                            Price = reader.GetDecimal(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return products;
        }
    }
}
