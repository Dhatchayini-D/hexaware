using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechshopData.data;

namespace TechshopData.data
{
    internal class Product
    {

        public int ProductID { get; set; } // Auto-incremented by the database  
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product() { } // Default constructor for data retrieval  

        public Product(string productName, string description, decimal price)
        {
            ProductName = productName;
            Description = description;
            Price = price;
        }



        public void Insert(DataConnector dbConnector, string productName, string description, decimal price)
        {
            // Use the GetConnection method from DataConnector  
            using (SqlConnection connection = dbConnector.GetConnection())
            {
                try
                {
                    connection.Open(); // Open the connection here if needed  
                    var command = new SqlCommand(
                        "INSERT INTO products (product_name, description, price) VALUES (@ProductName, @Description, @Price)",
                        connection
                    );

                    // Parameters for the query  
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Price", price);

                    command.ExecuteNonQuery(); // Execute the command  
                }
                catch (Exception ex)
                {
                    // Handle exceptions  
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                // No need to explicitly close the connection; the using statement handles that.  
            }
        }
        public void Update(DataConnector dbConnector)
        {
            using (SqlConnection connection = dbConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "UPDATE products SET product_name = @ProductName, description = @Description, price = @Price WHERE product_id = @ProductID",
                        connection
                    );

                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
        public static Product GetProductByID(int productId, DataConnector dbConnector)
        {
            Product product = null;

            using (SqlConnection connection = dbConnector.GetConnection())
            {
                try
                {
                    connection.Open(); // Opening the connection here is fine.  

                    var command = new SqlCommand("SELECT * FROM products WHERE product_id = @ProductID", connection);
                    command.Parameters.AddWithValue("@ProductID", productId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product(
                                reader["product_name"].ToString(),
                                reader["description"].ToString(),
                                Convert.ToDecimal(reader["price"])
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            } // The connection will automatically close here.  

            return product; // Return the retrieved product, or null if not found.  
        }


        public static List<Product> GetAllProducts(DataConnector dbConnector)
        {
            List<Product> products = new List<Product>();

            // 🔽 Create instance of DataConnector
            DataConnector connector = new DataConnector();

            try
            {
                connector.OpenConnection();

                // 🔽 Use connection from DataConnector
                var command = new SqlCommand("SELECT * FROM Products", connector.GetConnection());

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
            finally
            {
                connector.CloseConnection();
            }

            return products;
        }
    }
}
