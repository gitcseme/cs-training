using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Saying_Hi
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^[Hh][Ii]\s[^Dd]";
            string input;

            while (n-- > 0)
            {
                input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
