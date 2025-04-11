using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlstatements
{
    using System;

    class LoanEligibility
    {
        static void Main()
        {
            Console.Write("Enter Credit Score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter Annual Income: ");
            double income = double.Parse(Console.ReadLine());

            if (creditScore > 700 && income >= 50000)
            {
                Console.WriteLine("You are eligible for a loan.");
            }
            else
            {
                Console.WriteLine("You are not eligible for a loan.");
            }
        }
    }

}
