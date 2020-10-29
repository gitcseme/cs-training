using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class IP_AddressValidation
    {
        static void Main(string[] args)
        {
            string pattern = @"^((([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])|([0-9a-f]{1,4}\:){1,7}[0-9a-f]{1,4})$";
            List<string> ans = new List<string>();

            int n = int.Parse(Console.ReadLine());
            string input;
            while (n-- > 0)
            {
                input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                {
                    ans.Add(input.Contains(".") ? "IPv4" : "IPv6");
                }
                else
                    ans.Add("Neither");
            }

            foreach (var item in ans)
            {
                Console.WriteLine(item);
            }
        }
    }
}
