using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Sub_Word
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            string input;
            string pattern = "\\b\\w+\\b";

            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                input = Console.ReadLine();
                var result = Regex.Match(input, pattern);
                while (result.Success)
                {
                    words.Add(result.Value);
                    result = result.NextMatch();
                }
            }

            List<int> matchCount = new List<int>();
            int q = int.Parse(Console.ReadLine());
            int cnt;
            while (q-- > 0)
            {
                input = Console.ReadLine();
                pattern = $"\\b\\w+{input}\\w+\\b";
                cnt = 0;
                foreach (string word in words)
                {
                    var match = Regex.Match(word, pattern);
                    if (match.Success) ++cnt;
                }
                matchCount.Add(cnt);
            }

            foreach (var item in matchCount)
            {
                Console.WriteLine(item);
            }
        }
    }
}
