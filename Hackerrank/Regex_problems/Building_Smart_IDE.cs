using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Building_Smart_IDE
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                string pattern = @"\/\/.*|\/\*[\S\s]*?\*\/";
                string code = reader.ReadToEnd();
                List<string> comments = new List<string>();

                var match = Regex.Match(code, pattern);

                while (match.Success)
                {
                    string cmt = match.Value.Trim();

                    if (cmt.Contains("\n"))
                    {
                        var cmts = cmt.Split(new char[] { '\n' });
                        foreach (var c in cmts)
                        {
                            comments.Add(c.Trim());
                        }
                    }
                    else
                        comments.Add(cmt);

                    match = match.NextMatch();
                }

                foreach (var comment in comments)
                {
                    Console.WriteLine(comment);
                }
            }
        }
    }
}
