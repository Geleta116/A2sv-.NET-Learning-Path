using System;

namespace shapeHierarchy 
{
    public class Shape
    {
        public string Name { get; private set; }

        public Shape (string Name)
        {
            this.Name = Name;
        }

        public virtual double CalculateArea()
        {
            return 0;
        }
    }

    public class Circle : Shape
    {
        private double Radius;

        public Circle(double r) : base("Circle")
        {
            Radius = r;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        private readonly double Width;
        private readonly double Height;

        public Rectangle(double Height, double Width) : base("Rectangle")
        {
            this.Width = Width;
            this.Height = Height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : Shape
    {
        double Base;
        double Height;

        public Triangle(double Height, double Base) : base("Triangle")
        {
            this.Base = Base;
            this.Height = Height;
        }

        public override double CalculateArea()
        {
            return (Base * Height) / 2;
        }
    }

    public class shapeHierarchy
    {
        public static void PrintShapeArea(Shape shape)
        {
            Console.WriteLine($"The are for this {shape.Name} is {shape.CalculateArea()}");
           
        }

        static void Main(string[] args)
        {
            Circle circle = new(2.1);
            Rectangle rectangle = new(2,4);
            Triangle triangle = new(2,3);
            PrintShapeArea(circle);
            PrintShapeArea(rectangle);
            PrintShapeArea(triangle);
        }

    }
}
    
