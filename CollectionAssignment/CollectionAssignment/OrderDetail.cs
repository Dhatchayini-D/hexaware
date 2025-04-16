using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssignment
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }  // FK to Order
        public int ProductId { get; set; }  // FK to Product
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderDetail(int orderDetailId, int orderId, int productId, int quantity, decimal unitPrice)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public override string ToString()
        {
            return $"OrderDetailId: {OrderDetailId}, OrderId: {OrderId}, ProductId: {ProductId}, Quantity: {Quantity}, UnitPrice: {UnitPrice:C}";
        }
    }

}
