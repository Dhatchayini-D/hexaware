using System;
using System.Text.RegularExpressions;

class PasswordValidator
{
    static void Main()
    {
        Console.Write("Create your password: ");
        string password = Console.ReadLine();

        bool isValid = password.Length >= 8 &&
                       Regex.IsMatch(password, @"[A-Z]") &&
                       Regex.IsMatch(password, @"\d");

        if (isValid)
            Console.WriteLine("Password is valid.");
        else
            Console.WriteLine("Password is invalid. Must be at least 8 characters long, include an uppercase letter and a digit.");
    }
}
