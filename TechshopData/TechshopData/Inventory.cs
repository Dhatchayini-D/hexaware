
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechshopData.data
{
    internal class Inventory
    {
        public int ProductID { get; set; }
        public int QuantityInStock { get; set; }

        public void AddInventory(int productId, int quantityInStock, DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("INSERT INTO Inventory (ProductID, QuantityInStock) VALUES (@ProductID, @QuantityInStock)", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@QuantityInStock", quantityInStock);
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }

        // If GetInventoryByProductID is not meant to be static, remove the static modifier  
        public static Inventory GetInventoryByProductID(int productId, DataConnector dbConnector)
        {
            Inventory inventory = null;

            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("SELECT * FROM Inventory WHERE ProductID = @ProductID", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@ProductID", productId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inventory = new Inventory
                        {
                            ProductID = reader.GetInt32(0), // Adjust based on your table structure  
                            QuantityInStock = reader.GetInt32(1)
                        };
                    }
                }
            }
            finally
            {
                dbConnector.CloseConnection();
            }

            return inventory;
        }
    }
}
