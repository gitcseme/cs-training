using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Split_PhoneNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(\d{1,3})[ -](\d{1,3})[ -](\d{4,10})";
            string input;

            while (n-- > 0)
            {
                input = Console.ReadLine();
                var result = Regex.Match(input, pattern);
                Console.WriteLine($"CountryCode={result.Groups[1].Value},LocalAreaCode={result.Groups[2].Value},Number={result.Groups[3].Value}");
            }
        }
    }
}
