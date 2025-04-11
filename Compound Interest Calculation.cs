using System;
using System;

class CompoundInterest
{
    static void Main()
    {
        Console.Write("Enter number of customers: ");
        int customers = int.Parse(Console.ReadLine());

        for (int i = 1; i <= customers; i++)
        {
            Console.WriteLine($"\nCustomer {i}:");
            Console.Write("Enter initial balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter annual interest rate (%): ");
            double rate = double.Parse(Console.ReadLine());

            Console.Write("Enter number of years: ");
            int years = int.Parse(Console.ReadLine());

            double futureBalance = balance * Math.Pow(1 + rate / 100, years);
            Console.WriteLine($"Future balance after {years} years: ${futureBalance:F2}");
        }
    }
}

