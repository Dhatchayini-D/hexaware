using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshop_ass
{
    internal class Order
    {
            private int orderID;
            private Customer customer;
            private DateTime orderDate;
            private decimal totalAmount;
            private string orderStatus;
            private List<OrderDetail> orderDetails;


            public Order(int orderID, Customer customer)
            {
                this.orderID = orderID;
                this.customer = customer;
                orderDate = DateTime.Now;
                totalAmount = 0.0m;
                orderStatus = "Processing";
                orderDetails = new List<OrderDetail>();
            }


            public int OrderID => orderID;
            public Customer Customer => customer;
            public DateTime OrderDate => orderDate;
            public decimal TotalAmount => totalAmount;


            public decimal CalculateTotalAmount()
            {
                totalAmount = 0;
                foreach (var detail in orderDetails)
                {
                    totalAmount += detail.CalculateSubtotal();
                }
                return totalAmount;
            }

            public void AddOrderDetail(OrderDetail orderDetail)
            {
                orderDetails.Add(orderDetail);
            }

            public List<string> GetOrderDetails()
            {
                List<string> details = new List<string>();
                foreach (var detail in orderDetails)
                {
                    details.Add(detail.GetOrderDetailInfo());
                }
                return details;
            }

            public void UpdateOrderStatus(string status)
            {
                orderStatus = status;
            }

            public void CancelOrder()
            {
                foreach (var detail in orderDetails)
                {

                }
                orderDetails.Clear();
            }

            public string GetOrderStatus() => orderStatus;
        }
    }

