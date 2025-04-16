namespace techshop_ass
{
    internal class Program
    {
        
            static void Main(string[] args)
            {
                var customer1 = new Customer(1, "John", "Doe", "john.doe@example.com", "123-456-7890", "123 Main St");
                var customer2 = new Customer(2, "Jane", "Smith", "jane.smith@example.com", "987-654-3210", "456 Elm St");


                var product1 = new Product(1, "Smartphone", "Latest model", 699.99m);
                var product2 = new Product(2, "Laptop", "High performance laptop", 1299.99m);


                var inventory1 = new Inventory(1, product1, 25);
                var inventory2 = new Inventory(2, product2, 10);


                Console.WriteLine("Initial Inventory:");
                inventory1.ListAllProducts();
                inventory2.ListAllProducts();
                Console.WriteLine();


                var order1 = new Order(1, customer1);


                var orderDetail1 = new OrderDetail(1, order1, product1, 2);
                var orderDetail2 = new OrderDetail(2, order1, product2, 1);


                order1.AddOrderDetail(orderDetail1);
                order1.AddOrderDetail(orderDetail2);


                customer1.UpdateTotalOrders();


                decimal totalAmount = order1.CalculateTotalAmount();


                Console.WriteLine("Order Details:");
                foreach (var detail in order1.GetOrderDetails())
                {
                    Console.WriteLine(detail);
                }
                Console.WriteLine($"Total Amount: {totalAmount:C}");
                Console.WriteLine();


                inventory1.RemoveFromInventory(orderDetail1.Quantity);
                inventory2.RemoveFromInventory(orderDetail2.Quantity);


                Console.WriteLine("Updated Inventory After Order:");
                inventory1.ListAllProducts();
                inventory2.ListAllProducts();
                Console.WriteLine();


                Console.WriteLine("Low Stock Products:");
                var lowStockProducts1 = inventory1.ListLowStockProducts(5);
                foreach (var product in lowStockProducts1)
                {
                    Console.WriteLine(product.GetProductDetails());
                }

                Console.WriteLine("Out of Stock Products:");
                var outOfStockProducts = inventory2.ListOutOfStockProducts();
                foreach (var product in outOfStockProducts)
                {
                    Console.WriteLine(product.GetProductDetails());
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    
