using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.PointLine
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
