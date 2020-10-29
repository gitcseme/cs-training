using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Hackerrank_Tweets
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = "\\b[#@]?HackerRank\\b";
            string input;
            int count = 0;

            while (n-- > 0)
            {
                input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
                    ++count;
            }

            Console.WriteLine(count);
        }
    }
}
