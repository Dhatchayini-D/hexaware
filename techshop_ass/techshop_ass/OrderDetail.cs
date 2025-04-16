using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshop_ass
{
    internal class OrderDetail
    {
        private int orderDetailID;
        private Order order;
        private Product product;
        private int quantity;


        public OrderDetail(int orderDetailID, Order order, Product product, int quantity)
        {
            this.orderDetailID = orderDetailID;
            this.order = order;
            this.product = product;
            Quantity = quantity;
        }

        // Properties  
        public int OrderDetailID => orderDetailID;
        public Order Order => order;
        public Product Product => product;

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity must be a positive integer");
                quantity = value;
            }
        }


        public decimal CalculateSubtotal() => Quantity * product.Price;

        public string GetOrderDetailInfo()
        {
            return $"{orderDetailID}: Product: {product.GetProductDetails()}, Quantity: {quantity}, Subtotal: {CalculateSubtotal():C}";
        }

        public void UpdateQuantity(int quantity) => Quantity = quantity; // Use the property setter for validation  

        public void AddDiscount(decimal discountPercentage)
        {

        }
    }
}
    
