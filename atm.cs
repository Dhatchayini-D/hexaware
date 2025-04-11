using System;
using System;

class ATM
{
    static void Main()
    {
        double balance;
        Console.Write("Enter your current balance: ");
        balance = double.Parse(Console.ReadLine());

        Console.WriteLine("Choose an option:\n1. Check Balance\n2. Withdraw\n3. Deposit");
        int option = int.Parse(Console.ReadLine());

        if (option == 1)
        {
            Console.WriteLine($"Your balance is: ${balance}");
        }
        else if (option == 2)
        {
            Console.Write("Enter amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());

            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else if (amount % 100 == 0 || amount % 500 == 0)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawal successful. New balance: ${balance}");
            }
            else
            {
                Console.WriteLine("Amount must be in multiples of 100 or 500.");
            }
        }
        else if (option == 3)
        {
            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());
            balance += amount;
            Console.WriteLine($"Deposit successful. New balance: ${balance}");
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }
    }
}

