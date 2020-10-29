using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class HTML_tag
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine().Trim());
            string input;
            //string pattern = @"<\s*(\w+)\s*.*?>";
            string pattern = @"(?<=<)\s*\w+";
            SortedSet<string> tags = new SortedSet<string>();

            while (t-- > 0)
            {
                input = Console.ReadLine();

                var result = Regex.Match(input, pattern);
                while (result.Success)
                {
                    tags.Add(result.Value.Trim());
                    result = result.NextMatch();
                }
            }

            string ans = string.Join(";", tags);
            Console.WriteLine(ans);
        }
    }
}
