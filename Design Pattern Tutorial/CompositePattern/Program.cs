using System;
using System.Collections.Generic;
using System.Text;

// composite patterm => objects inside object.

namespace CompositePattern
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color;
        public List<GraphicObject> Children = new List<GraphicObject>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
              .AppendLine(Name);

            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }
    }

    public class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
    }

    class Program
    {
        static void Main(string[] args)
        {
            GraphicObject drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Circle { Color = "Red" });
            drawing.Children.Add(new Square { Color = "Yellow" });

            GraphicObject subDrawing = new GraphicObject { Name = "SubGroup" };
            subDrawing.Children.Add(new Circle { Color = "Blue" });
            subDrawing.Children.Add(new Square { Color = "Blue" });

            GraphicObject subsubDrawing = new GraphicObject { Name = "SubSubGroup" };
            subsubDrawing.Children.Add(new Circle { Color = "Red" });
            subsubDrawing.Children.Add(new Square { Color = "Red" });
            subDrawing.Children.Add(subsubDrawing);

            drawing.Children.Add(subDrawing);
            Console.WriteLine(drawing);
        }
    }
}
