using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechshopData.data;

namespace TechshopData.data
{
    internal class OrderDetail
    {
        public int OrderDetailID { get; private set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public OrderDetail(int orderId, int productId, int quantity)
        {
            OrderID = orderId;
            ProductID = productId;
            Quantity = quantity;
        }

        public void AddOrderDetail(DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@OrderID", OrderID);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@Quantity", Quantity);

                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }

        public static OrderDetail GetOrderDetailByID(int orderDetailId, DataConnector dbConnector)
        {
            OrderDetail orderDetail = null;
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("SELECT * FROM OrderDetails WHERE OrderDetailID = @OrderDetailID", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@OrderDetailID", orderDetailId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orderDetail = new OrderDetail(
                            (int)reader["OrderID"],
                            (int)reader["ProductID"],
                            (int)reader["Quantity"]
                        )
                        {
                            OrderDetailID = (int)reader["OrderDetailID"]
                        };
                    }
                }
            }
            finally
            {
                dbConnector.CloseConnection();
            }
            return orderDetail;
        }

        public void UpdateOrderDetail(DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("UPDATE OrderDetails SET Quantity = @Quantity WHERE OrderDetailID = @OrderDetailID", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@OrderDetailID", OrderDetailID);
                command.Parameters.AddWithValue("@Quantity", Quantity);

                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }

        public void DeleteOrderDetail(DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("DELETE FROM OrderDetails WHERE OrderDetailID = @OrderDetailID", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@OrderDetailID", OrderDetailID);

                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }
    }
}
