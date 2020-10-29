using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Valid_PAN_format
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^[A-Z]{5}[\d]{4}[A-Z]$";
            string input;

            while (n-- > 0)
            {
                input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}
