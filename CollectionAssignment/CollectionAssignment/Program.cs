using System;
using System.Collections.Generic;

namespace CollectionAssignment
{
    class Program
    {
        class Product
        {
            public int Id;
            public string Name;
            public decimal Price;
            public string SKU;
            public int Stock;
        }

        class Order
        {
            public int Id;
            public Product Product;
            public int Quantity;
            public string Status;
        }

        class Payment
        {
            public int OrderId;
            public decimal Amount;
            public string Status;
        }

        static void Main()
        {
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();
            List<Payment> payments = new List<Payment>();

            //  Add product
            Product iphone = new Product { Id = 1, Name = "iPhone 14", Price = 80000, SKU = "SKU1001", Stock = 5 };
            products.Add(iphone);
            Console.WriteLine(" Product added successfully!");

            // Order iPhone
            try
            {
                int quantity = 2;
                if (iphone.Stock >= quantity)
                {
                    iphone.Stock -= quantity;
                    Order order = new Order { Id = 1, Product = iphone, Quantity = quantity, Status = "Completed" };
                    orders.Add(order);
                    Console.WriteLine($" Order placed for {iphone.Name}");

                    Payment payment = new Payment { OrderId = 1, Amount = iphone.Price * quantity, Status = "Paid" };
                    payments.Add(payment);
                    Console.WriteLine($" Payment processed for Order ID {order.Id}");
                }
                else
                {
                    throw new Exception("Insufficient stock");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }

            //  Duplicate product
            try
            {
                if (products.Exists(p => p.SKU == "SKU1001"))
                    throw new Exception("Duplicate product SKU");

                products.Add(new Product { Id = 2, Name = "iPhone 14 Pro", Price = 90000, SKU = "SKU1001", Stock = 10 });
                Console.WriteLine(" Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }

            // Insufficient stock
            try
            {
                int quantity = 10;
                if (iphone.Stock >= quantity)
                {
                    iphone.Stock -= quantity;
                    orders.Add(new Order { Id = 2, Product = iphone, Quantity = quantity, Status = "Completed" });
                    Console.WriteLine($" Order placed for {iphone.Name}");
                }
                else
                {
                    throw new Exception("Insufficient stock");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }

            //  Product List
            Console.WriteLine(" Product List:");
            foreach (var p in products)
                Console.WriteLine($"[{p.Id}] {p.Name} - Smartphone - ₹{p.Price} (SKU: {p.SKU})");

            // Order Summary
            Console.WriteLine(" Order Summary:");
            foreach (var o in orders)
                Console.WriteLine($"Order ID: {o.Id} - {o.Product.Name} - Qty: {o.Quantity} - Status: {o.Status}");

            // Payments
            Console.WriteLine(" Payments:");
            foreach (var pay in payments)
                Console.WriteLine($"Order ID: {pay.OrderId} - ₹{pay.Amount} - Status: {pay.Status}");

            Console.ReadLine();
        }
    }
}
