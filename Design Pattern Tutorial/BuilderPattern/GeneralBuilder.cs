using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class HtmlElement
    {
        public string Name, Text;
        public int IndentSize = 4;
        public List<HtmlElement> Elements = new List<HtmlElement>();

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImp(int indent)
        {
            var sb = new StringBuilder();
            string i = new string(' ', IndentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', IndentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var el in Elements)
            {
                sb.Append(el.ToStringImp(indent + 1));
            }

            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImp(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string RootName;
        HtmlElement root = new HtmlElement();
        
        public HtmlBuilder(string rootName)
        {
            RootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            HtmlElement el = new HtmlElement(childName, childText);
            root.Elements.Add(el);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = RootName};
        }
    }

    class GeneralBuilder
    {
        static void Main(string[] args)
        {
            string hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb.ToString());

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("\n");


            HtmlBuilder builder = new HtmlBuilder("ul");

            // chain of object called Fluent Builder
            builder                             
                .AddChild("li", "Hello")
                .AddChild("li", "World")
                .AddChild("p", "This is a paragraph child");
            Console.WriteLine(builder.ToString());
            builder.Clear();
        }
    }
}
