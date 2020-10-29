using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class HTML_links
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = "<a href=\"([^\"]+)\".*?>(<\\w+>)*([^<>]*)<";
            string line;
            List<string> ans = new List<string>();

            while (n-- > 0)
            {
                line = Console.ReadLine();
                var match = Regex.Match(line, pattern);

                while (match.Success)
                {
                    string link_Text = match.Groups[1].Value.Trim() + "," + match.Groups[3].Value.Trim();
                    ans.Add(link_Text);
                    match = match.NextMatch();
                }
            }

            string f = string.Join("\n", ans);
            Console.WriteLine(f);
        }
    }
}
