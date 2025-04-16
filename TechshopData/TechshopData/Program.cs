using TechshopData.data;
using static System.Console;
using System.Collections.Generic;

namespace TechshopData
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DHATCHAYINI;Initial Catalog=tech;Integrated Security=True;";
            DataConnector dbConnector = new DataConnector(connectionString);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== TechShop Menu ===");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Inventory to First Product");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayProducts(dbConnector);
                        break;
                    case "2":
                        AddInventoryToFirstProduct(dbConnector);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-3.");
                        break;
                }
            }
        }

        static void DisplayProducts(DataConnector dbConnector)
        {
            List<Product> products = dbConnector.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            Console.WriteLine("\n--- Current Products ---");
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.ProductID}");
                Console.WriteLine($"Name: {p.ProductName}");
                Console.WriteLine($"Description: {p.Description}");
                Console.WriteLine($"Price: ₹{p.Price:F2}");
                Console.WriteLine("----------------------------");
            }
        }

        static void AddInventoryToFirstProduct(DataConnector dbConnector)
        {
            List<Product> products = dbConnector.GetAllProducts();

            if (products.Count > 0)
            {
                var inventory = new Inventory();
                int productIdToAddInventory = products[0].ProductID; // Use first product's ID
                inventory.AddInventory(productIdToAddInventory, 50, dbConnector);

                Console.WriteLine($"Inventory updated for product ID: {productIdToAddInventory}");

                // Retrieve inventory  
                Inventory existingInventory = Inventory.GetInventoryByProductID(productIdToAddInventory, dbConnector);
                Console.WriteLine($"Current Inventory for product ID {productIdToAddInventory}: {existingInventory.QuantityInStock}");
            }
            else
            {
                Console.WriteLine("No products found to add inventory.");
            }
        }
    }
}
