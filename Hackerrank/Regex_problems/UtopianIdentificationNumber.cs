using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class UtopianIdentificationNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^[a-z]{0,3}[\d]{2,8}[A-Z]{3,}$";
            string input;

            while (n-- > 0)
            {
                input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                    Console.WriteLine("VALID");
                else
                    Console.WriteLine("INVALID");
            }
        }
    }
}
