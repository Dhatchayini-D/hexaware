using System;
using System.Collections.Generic;

class TransactionHistory
{
    static void Main()
    {
        List<string> transactions = new List<string>();
        double balance = 0.0;
        string choice;

        do
        {
            Console.WriteLine("Choose an option: deposit / withdraw / exit");
            choice = Console.ReadLine().ToLower();

            if (choice == "deposit")
            {
                Console.Write("Enter amount to deposit: ");
                double amount = double.Parse(Console.ReadLine());
                balance += amount;
                transactions.Add($"Deposited: ${amount}");
            }
            else if (choice == "withdraw")
            {
                Console.Write("Enter amount to withdraw: ");
                double amount = double.Parse(Console.ReadLine());
                if (amount <= balance)
                {
                    balance -= amount;
                    transactions.Add($"Withdrew: ${amount}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }

        } while (choice != "exit");

        Console.WriteLine("\nTransaction History:");
        foreach (var transaction in transactions)
        {
            Console.WriteLine(transaction);
        }
        Console.WriteLine($"Final Balance: ${balance}");
    }
}

