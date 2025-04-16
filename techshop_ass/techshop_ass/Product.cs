using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshop_ass
{
    internal class Product
    {
        private int productID;
        private string productName;
        private string description;
        private decimal price;

        public Product(int productID, string productName, string description, decimal price)
        {
            this.productID = productID;
            this.productName = productName;
            this.description = description;
            Price = price;
        }


        public int ProductID => productID;
        public string ProductName => productName;
        public string Description => description;

        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative");
                price = value;
            }
        }

        public string GetProductDetails()
        {
            return $"{productID}: {productName}, Description: {description}, Price: {price:C}";
        }

        public void UpdateProductInfo(string name = null, string description = null, decimal? price = null)
        {
            if (name != null) productName = name;
            if (description != null) this.description = description;
            if (price.HasValue) Price = price.Value;
        }

        public bool IsProductInStock()
        {
            return true;
        }
    }
}
    
