using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Find_hackerrank
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern0 = "^(hackerrank)$";
            string pattern1 = "^(hackerrank)";
            string pattern2 = "(hackerrank)$";
            string input;
            List<int> ans = new List<int>();

            while (n-- > 0)
            {
                input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern0))
                    ans.Add(0);
                else if (Regex.IsMatch(input, pattern1))
                    ans.Add(1);
                else if (Regex.IsMatch(input, pattern2))
                    ans.Add(2);
                else
                    ans.Add(-1);
            }

            foreach (var item in ans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
