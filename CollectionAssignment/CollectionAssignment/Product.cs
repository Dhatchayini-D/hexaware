using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssignment
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; } 
        public string Description { get; set; }

        public Product(int productId, string name, string category, decimal price, string sku, string description)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            Price = price;
            SKU = sku;
            Description = description;
        }

        public override string ToString()
        {
            return $"[{ProductId}] {Name} - {Category} - ₹{Price} (SKU: {SKU})";
        }
    }

}
