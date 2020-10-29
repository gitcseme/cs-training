using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class DetectEmailAddress
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"\w+[.\w]*@\w+[.\w]+\w+";

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
                    ans.Add(match.Value);
                    match = match.NextMatch();
                }
            }

            string f = string.Join(";", ans);
            Console.WriteLine(f);
        }
    }
}
