using System;

namespace BridgePattern
{
    /*
     G.O.F. => Bridge allows to decuples an abstruction from its implementation 
            so that the two can vary independently.
     */

    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"vector circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"raster circle of radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            Radius = radius;
        }

        public float Radius { get; }

        public override void Draw()
        {
            this.renderer.RenderCircle(Radius);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new RasterRenderer();
            Shape circle = new Circle(renderer, 5);
            circle.Draw();
        }
    }
}
