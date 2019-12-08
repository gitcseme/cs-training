using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.PointLine
{
    public class Printer : Draw
    {
        public void PrintPoint(Point p)
        {
            Console.WriteLine($"({p.X}, {p.Y})"); // Suppose it is a complex task.
        }
    }
}
