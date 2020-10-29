using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class HTML_Attributes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string tagPat = @"<(\w+)[^>]*>";
            string attrPat = "(\\w+)=[\"\']";
            string input;
            SortedDictionary<string, SortedSet<string>> tagsWithAttributes = new SortedDictionary<string, SortedSet<string>>();

            while (n-- > 0)
            {
                input = Console.ReadLine();
                var matches = Regex.Matches(input, tagPat);

                foreach (Match match in matches)
                {
                    string tag = match.Groups[1].Value;
                    if (!tagsWithAttributes.ContainsKey(tag))
                        tagsWithAttributes[tag] = new SortedSet<string>();

                    var match2 = Regex.Match(match.Groups[0].Value, attrPat);
                    while (match2.Success)
                    {
                        tagsWithAttributes[tag].Add(match2.Groups[1].Value);
                        match2 = match2.NextMatch();
                    }
                }
            }

            foreach (var item in tagsWithAttributes)
            {
                Console.WriteLine(item.Key + ":" + string.Join(",", item.Value));
            }
        }
    }
}
