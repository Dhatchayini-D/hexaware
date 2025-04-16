using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssignment.Utils
{
    // Custom exception class
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    // Sample Product class for context
    public class Product
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int productId, string sku, string name, decimal price)
        {
            ProductId = productId;
            SKU = sku;
            Name = name;
            Price = price;
        }
    }

    // Product validation 
    public static class ProductValidator
    {
        public static void CheckDuplicateProduct(List<Product> products, Product newProduct)
        {
            if (products.Any(p => p.SKU == newProduct.SKU))
            {
                throw new CustomException($"Product with SKU '{newProduct.SKU}' already exists.");
            }
        }

        public static void ValidateProductData(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new CustomException("Product name cannot be empty.");

            if (product.Price <= 0)
                throw new CustomException("Product price must be greater than zero.");
        }
    }
}
