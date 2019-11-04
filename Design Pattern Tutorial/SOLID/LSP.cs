using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Rectangle
    {
        public Rectangle() { }
        public Rectangle(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
        }

        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        public override string ToString()
        {
            return $"Height: {Height} Width: {Width} ";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Height = base.Width = value; }
        }
    }

    public class LSP
    {
        public static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc}Area: {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} Area: {Area(sq)}");
        }
    }
}
