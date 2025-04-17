using System;
using System.Text.RegularExpressions;

namespace CareerHub.Util
{
    public static class OtherUtility
    {
        // Method to validate email format
        public static bool IsValidEmail(string email)
        {
            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email validation failed: " + ex.Message);
                return false;
            }
        }

        // Method to check if a salary is valid (non-negative)
        public static bool IsValidSalary(decimal salary)
        {
            return salary >= 0;
        }

        // Method to check if a file size is within the allowed limit (in bytes)
        public static bool IsValidFileSize(long fileSize, long maxSizeInBytes)
        {
            return fileSize <= maxSizeInBytes;
        }

        // Method to convert a string to Title Case
        public static string ToTitleCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }

        // Method to validate date (for example, checking if a date is not in the future)
        public static bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}

