using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshop_ass;

namespace techshop_ass
{
    internal class Inventory
    {
        private int inventoryID;
        private Product product;
        private int quantityInStock;
        private DateTime lastStockUpdate;


        public Inventory(int inventoryID, Product product, int quantityInStock)
        {
            this.inventoryID = inventoryID;
            this.product = product;
            QuantityInStock = quantityInStock;
            lastStockUpdate = DateTime.Now;
        }


        public int InventoryID => inventoryID;
        public Product Product => product;

        public int QuantityInStock
        {
            get => quantityInStock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity in stock cannot be negative");
                }
                quantityInStock = value;
                lastStockUpdate = DateTime.Now;
            }
        }


        public void AddToInventory(int quantity)
        {
            if (quantity > 0)
            {
                QuantityInStock += quantity;
            }
            else
            {
                throw new ArgumentException("Quantity to add must be positive");
            }
        }

        public void RemoveFromInventory(int quantity)
        {
            if (quantity > 0 && quantity <= QuantityInStock)
            {
                QuantityInStock -= quantity;
            }
            else
            {
                throw new ArgumentException("Quantity to remove must be positive and less than or equal to available stock");
            }
        }

        public bool IsProductAvailable(int quantityToCheck) => quantityToCheck <= QuantityInStock;

        public decimal GetInventoryValue() => QuantityInStock * Product.Price;


        public List<Product> ListLowStockProducts(int threshold)
        {
            List<Product> lowStockProducts = new List<Product>();


            if (QuantityInStock < threshold)
            {
                lowStockProducts.Add(Product);
            }

            return lowStockProducts;
        }

        public List<Product> ListOutOfStockProducts()
        {
            List<Product> outOfStockProducts = new List<Product>();

            if (QuantityInStock == 0)
            {
                outOfStockProducts.Add(Product);
            }

            return outOfStockProducts;
        }

        public void ListAllProducts()
        {
            Console.WriteLine($"Product: {Product.ProductName}, Quantity in Stock: {QuantityInStock}, Price: {Product.Price:C}");
        }
    }
}


