using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace assignmnet_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //conditional statements(loan elgiblity)
            Console.Write("Enter credit score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter annual income: ");
            double annualIncome = double.Parse(Console.ReadLine());

            if (creditScore > 700 && annualIncome >= 50000)
            {
                Console.WriteLine("Congratulations! You are eligible for a loan.");
            }
            else
            {
                Console.WriteLine("Sorry, you are not eligible for a loan.");
            }

            //nested conditional statement(atm transaction)
            double balance = 0;

            while (true)
            {
                Console.Write("Enter current balance: ");
                if (double.TryParse(Console.ReadLine(), out balance) && balance >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid numeric balance.");
            }

            while (true)
            {
                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int option;

                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Your current balance is: $" + balance);
                            break;

                        case 2:
                            Console.Write("Enter amount to withdraw: ");
                            if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                            {
                                if (withdrawAmount > balance)
                                {
                                    Console.WriteLine("Insufficient funds.");
                                }
                                else if (withdrawAmount % 100 != 0 && withdrawAmount % 500 != 0)
                                {
                                    Console.WriteLine("Withdrawal amount must be in multiples of 100 or 500.");
                                }
                                else
                                {
                                    balance -= withdrawAmount;
                                    Console.WriteLine("Withdrawal successful. New balance: $" + balance);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid numeric amount.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter amount to deposit: ");
                            if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
                            {
                                balance += depositAmount;
                                Console.WriteLine("Deposit successful. New balance: $" + balance);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a positive numeric amount.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Exiting ATM. Thank you!");
                            return; // Exit the program  

                        default:
                            Console.WriteLine("Invalid option selected. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to your selection.");
                }
                //loop structures(compound Intrest)

                Console.Write("Enter the number of customers: ");
                int customerCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < customerCount; i++)
                {
                    Console.WriteLine($"Customer {i + 1}:");
                    Console.Write("Enter initial balance: ");
                    double initialBalance = double.Parse(Console.ReadLine());

                    Console.Write("Enter annual interest rate (in %): ");
                    double annualInterestRate = double.Parse(Console.ReadLine());

                    Console.Write("Enter number of years: ");
                    int years = int.Parse(Console.ReadLine());

                    double futureBalance = initialBalance * Math.Pow((1 + annualInterestRate / 100), years);
                    Console.WriteLine("Future balance after " + years + " years: $" + futureBalance);

                    // Looping, Array and Data Validation,Account Balance Checking
                    string[] accountNumbers = { "INDB1234", "INDB5678", "INDB9101" };
                    double[] balances = { 1000.00, 1500.50, 2000.75 };

                    while (true)
                    {
                        Console.Write("Enter account number (format: INDBXXXX): ");
                        string accountNumber = Console.ReadLine();

                        if (IsValidAccountNumber(accountNumber))
                        {
                            int index = Array.IndexOf(accountNumbers, accountNumber);
                            if (index != -1)
                            {
                                Console.WriteLine("Your account balance is: $" + balances[index]);
                            }
                            else
                            {
                                Console.WriteLine("Account number not found.");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid account number. Please try again.");
                        }
                    }
                }

                static bool IsValidAccountNumber(string accountNumber)
                {
                    return Regex.IsMatch(accountNumber, @"^INDB\d{4}$");
                }


                //password validation
                Console.Write("Create a password: ");
                string Password = Console.ReadLine();

                if (IsValidPassword(Password))
                {
                    Console.WriteLine("Password is valid.");
                }
                else
                {
                    Console.WriteLine("Password is invalid. It must be at least 8 characters long, contain at least one uppercase letter and one digit.");
                }
            }

            static bool IsValidPassword(string password)
            {
                return password.Length >= 8 &&
                       password.Any(char.IsUpper) &&
                       password.Any(char.IsDigit);
            }

            //Transaction History Management

            string[] transactions = new string[100];
            int transactionCount = 0;
            string input;

            Console.WriteLine("Bank Transaction Management System");

            while (true)
            {
                Console.Write("Enter transaction (e.g., Deposit $100, Withdraw $50) or type 'exit' to finish: ");
                input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break; // Exit the loop if the user types 'exit'  
                }

                // Check if there is space to add a new transaction  
                if (transactionCount < transactions.Length)
                {
                    transactions[transactionCount] = input; // Store the transaction in the array  
                    transactionCount++; // Increment the transaction count  
                    Console.WriteLine("Transaction added!");
                }
                else
                {
                    Console.WriteLine("Transaction limit reached. Cannot add more transactions.");
                }
            }
            Console.WriteLine("\nTransaction History:");
            for (int i = 0; i < transactionCount; i++)
            {
                Console.WriteLine(transactions[i]);
            }
            //password validation
            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            if (IsValidPassword(password))
            {
                Console.WriteLine("Password is valid.");
            }
            else
            {
                Console.WriteLine("Password is invalid. It must be at least 8 characters long, contain at least one uppercase letter and one digit.");
            }
        }

        static bool IsValidPassword(string password)
        {
            return password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsDigit);
        }
    }
}

