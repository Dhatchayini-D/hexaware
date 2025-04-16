using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CollectionAssignment.Orders
{


    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }  // FK Reference
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public string Status { get; set; }  // e.g., Placed, Processing, Shipped, Cancelled

        public Order(int orderId, int customerId, DateTime orderDate, List<OrderDetail> orderDetails, string status)
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderDetails = orderDetails ?? new List<OrderDetail>();
            Status = status;
        }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, CustomerId: {CustomerId}, OrderDate: {OrderDate.ToShortDateString()}, Status: {Status}";
        }
    }
}

