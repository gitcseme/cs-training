using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Product(string Name, Color Color, Size Size)
        {
            this.Name = Name;
            this.Color = Color;
            this.Size = Size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size)
                    yield return p;
            }
        }
    }

    public interface ISpecification<T> 
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> Spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class ColorSizeSpecification : ISpecification<Product>
    {
        public ColorSizeSpecification(Color color, Size size)
        {
            Color = color;
            Size = size;
        }

        public Color Color { get; }
        public Size Size { get; }

        public bool IsSatisfied(Product t)
        {
            return t.Color == Color && t.Size == Size;
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> Spec)
        {
            foreach (var item in items)
            {
                if (Spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }

    public class OCP
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Apple", Color.Green, Size.Small),
                new Product("Tree", Color.Green, Size.Large),
                new Product("House", Color.Blue, Size.Large)
            };

            ProductFilter pf = new ProductFilter();

            Console.WriteLine("Green Color filter(old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} {p.Color}");
            }

            Console.WriteLine("\nGreen Color filter(new):");
            BetterFilter bf = new BetterFilter();
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} {p.Color}");
            }

            Console.WriteLine("\nGreen and Large product:");
            foreach (var p in bf.Filter(products, new ColorSizeSpecification(Color.Green, Size.Large)))
            {
                Console.WriteLine($" - {p.Name} = {p.Color}, {p.Size}");
            }
        }
    }
}
