using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Regex_problems
{
    class Hackerrank_Language
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string valid_languages = "C:CPP:JAVA:PYTHON:PERL:PHP:RUBY:CSHARP:HASKELL:CLOJURE:BASH:SCALA:ERLANG:CLISP:LUA:BRAINFUCK:JAVASCRIPT:GO:D:OCAML:R:PASCAL:SBCL:DART:GROOVY:OBJECTIVEC";
            valid_languages = valid_languages.Replace(":", "|");
            string pattern = "^[\\d]{5,6}\\s("+valid_languages+")$";
            List<string> ans = new List<string>();

            while (n-- > 0)
            {
                var input = Console.ReadLine();
                if (Regex.IsMatch(input, pattern))
                    ans.Add("VALID");
                else
                    ans.Add("INVALID");
            }

            string f = string.Join("\n", ans);
            Console.WriteLine(f);
        }
    }
}
