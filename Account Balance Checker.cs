using System;
using System.Text.RegularExpressions;

class AccountChecker
{
    static void Main()
    {
        string[] accountNumbers = { "INDB1234", "INDB5678", "INDB9999" };
        double[] balances = { 1500.50, 3000.75, 10000.00 };

        while (true)
        {
            Console.Write("Enter your account number: ");
            string input = Console.ReadLine();

            if (Regex.IsMatch(input, @"^INDB\d{4}$"))
            {
                bool found = false;
                for (int i = 0; i < accountNumbers.Length; i++)
                {
                    if (input == accountNumbers[i])
                    {
                        Console.WriteLine($"Your balance is: ${balances[i]}");
                        found = true;
                        break;
                    }
                }

                if (!found)
                    Console.WriteLine("Account not found.");
                else
                    break;
            }
            else
            {
                Console.WriteLine("Invalid account number format. Try again.");
            }
        }
    }
}

