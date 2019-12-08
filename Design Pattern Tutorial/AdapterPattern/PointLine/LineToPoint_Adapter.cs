using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.PointLine
{
    public class LineToPoint_Adapter
    {
        public List<Point> Points { get; set; }
        private Printer Printer { get; set; }

        public LineToPoint_Adapter(Line line)
        {
            Points = new List<Point>();
            Printer = new Printer();

            for (int i = Math.Min(line.X1, line.Y1); i <= Math.Max(line.X2, line.Y2); ++i)
            {
                Points.Add(new Point(1, i));
            }
        }

        public void print()
        {
            foreach (var point in Points)
            {
                Printer.PrintPoint(point);
            }
        }
    }
}
