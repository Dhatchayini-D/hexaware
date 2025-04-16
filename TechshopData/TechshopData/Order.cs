using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechshopData.data;

namespace TechshopData.data
{
    internal class Order
    {
        public int OrderID { get; private set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

        public Order(int customerId, DateTime orderDate, string status, decimal totalAmount)
        {
            CustomerID = customerId;
            OrderDate = orderDate;
            Status = status;
            TotalAmount = totalAmount;
        }

        public void PlaceOrder(DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("INSERT INTO Orders (CustomerID, OrderDate, Status, TotalAmount) VALUES (@CustomerID, @OrderDate, @Status, @TotalAmount)", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@OrderDate", OrderDate);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@TotalAmount", TotalAmount);

                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }

        public static Order GetOrderByID(int orderId, DataConnector dbConnector)
        {
            Order order = null;
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("SELECT * FROM Orders WHERE OrderID = @OrderID", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@OrderID", orderId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new Order(
                            (int)reader["CustomerID"],
                            (DateTime)reader["OrderDate"],
                            reader["Status"].ToString(),
                            (decimal)reader["TotalAmount"]
                        )
                        {
                            OrderID = (int)reader["OrderID"]
                        };
                    }
                }
            }
            finally
            {
                dbConnector.CloseConnection();
            }
            return order;
        }

        public void UpdateOrder(DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("UPDATE Orders SET Status = @Status, TotalAmount = @TotalAmount WHERE OrderID = @OrderID", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@OrderID", OrderID);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@TotalAmount", TotalAmount);

                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }

        public void DeleteOrder(DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@OrderID", OrderID);

                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }
    }
}