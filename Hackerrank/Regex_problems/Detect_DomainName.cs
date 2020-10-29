using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Detect_DomainName
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"http[s]?:\/\/(ww[w2]\.)?(([A-Za-z0-9-]+\.)+[a-zA-Z-]+)";
            SortedSet<string> ans = new SortedSet<string>(Comparer<string>.Create((x, y) => {
                int mx = Math.Max(x.Length, y.Length);
                for (int i = 0; i < mx; ++i)
                {
                    int x1 = x[i];
                    int y1 = y[i];
                    if (x1 == y1) continue;
                    return x1 > y1 ? 1 : -1;
                }

                if (x.Length == y.Length) return 0;
                else return x.Length > y.Length ? 1 : -1;
            }));

            while (n-- > 0)
            {
                string line = Console.ReadLine();
                var match = Regex.Match(line, pattern);

                while (match.Success)
                {
                    string site = match.Groups[2].Value.Trim();

                    ans.Add(site);
                    match = match.NextMatch();
                }
            }

            string res = string.Join(";", ans);
            Console.WriteLine(res);
        }
    }
}
