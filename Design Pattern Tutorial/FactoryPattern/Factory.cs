using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    //public enum CoordinateSystem
    //{
    //    Cartesian,
    //    Polar
    //}

    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x: {x}, y: {y}";
        }

        public static Point Origin = new Point(0, 0);

        // Inner Factory
        public static class Factory
        {
            // factory method
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            // factory method
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

        //// factory method
        //public static Point NewCartesianPoint(double x, double y)
        //{
        //    return new Point(x, y);
        //}

        //// factory method
        //public static Point NewPolarPoint(double rho, double theta)
        //{
        //    return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        //}

        //public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
        //{
        //    switch(system)
        //    {
        //        case CoordinateSystem.Cartesian:
        //            x = a;
        //            y = b;
        //            break;
        //        case CoordinateSystem.Polar:
        //            x = a * Math.Cos(b);
        //            y = a * Math.Sin(b);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(system), system, null);
        //    }
        //}
    }

    public class Factory
    {
        static void Main(string[] args)
        {
            Point point = Point.Factory.NewPolarPoint(5.0, Math.PI / 2);
            Point origin = Point.Origin;
            Console.WriteLine(origin);
            Console.WriteLine(point);
        }
    }
}
