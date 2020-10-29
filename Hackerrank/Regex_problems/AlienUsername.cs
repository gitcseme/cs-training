using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class AlienUsername
    {
        static void Main(string[] args)
        {
            string pattern = "^[_|\\.][0-9]+[a-zA-Z]*[_]?$";
            List<string> ans = new List<string>();

            int n = int.Parse(Console.ReadLine());
            string input;
            while (n-- > 0)
            {
                input = Console.ReadLine();
                ans.Add(Regex.IsMatch(input, pattern) ? "VALID" : "INVALID");
            }

            foreach (var item in ans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
