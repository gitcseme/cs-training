using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Find_a_word
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"\b[\W]*foo[\W]*\b", line;
            List<string> sentances = new List<string>();

            while (n-- > 0)
            {
                line = Console.ReadLine();
                sentances.Add(line);
            }

            int t = int.Parse(Console.ReadLine());
            string word;
            List<int> ans = new List<int>();

            while (t-- > 0)
            {
                word = Console.ReadLine();
                string pat = pattern.Replace("foo", word);

                int count = 0;
                foreach (var sentance in sentances)
                {
                    var match = Regex.Matches(sentance, pat);
                    count += match.Count;
                }

                ans.Add(count);
            }

            Console.WriteLine(string.Join("\n", ans));
        }
    }
}
