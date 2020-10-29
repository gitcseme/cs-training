using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Stack_Exchange_Scraper
    {
        static void Main(string[] args)
        {
            string pattern = "href=\"\\/questions\\/(\\d+)\\/.+\">(.+)<\\/a>|\"relativetime\">(.+)<\\/span>";
            List<string> ans = new List<string>();

            using (StreamReader streamReader = new StreamReader(Console.OpenStandardInput()))
            {
                var lines = streamReader.ReadToEnd();
                var matches = Regex.Matches(lines, pattern);

                foreach (Match match in matches)
                {
                    var groups = match.Groups;
                    for (int i = 1; i < groups.Count; ++i)
                    {
                        if (groups[i].Success)
                        {
                            ans.Add(groups[i].Value);
                        }
                    }

                    if (ans.Count == 3)
                    {
                        Console.WriteLine(string.Join(";", ans));
                        ans.Clear();
                    }
                }
            }
        }
    }
}
