using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Creational;

class PrototypeExampleClientCode
{
    public void Run()
    {
        var circle = new Circle(5);
        var newCircle = new Circle(circle.Radius);

        var rectangle = new MyRectangle(10, 20);
        var newRectangle = new MyRectangle(rectangle.Width, rectangle.Height);

        var shapes = new List<IShape> { circle, rectangle };

        shapes.ForEach(shape =>
        {
            Console.WriteLine($"Area of {shape.GetType().Name}: {shape.Area()}");
        });

        var copyOfShapes = shapes.Select(shape => (IShape)shape.Clone()).ToList();
       

        copyOfShapes.ForEach(shape =>
            {
                Console.WriteLine($"Area of copied {shape.GetType().Name}: {shape.Area()}");
            });


    }
}

public interface IShape: ICloneable
{
    public double Area();
}

public class Circle: IShape
{
    public int Radius { get; set; }
    public Circle(int radius)
    {
        Radius = radius;
    }
    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public Circle(Circle other)
    {
        Radius = other.Radius;
    }
    public object Clone()
    {
        return new Circle(this);
    }
}

public class  MyRectangle: IShape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public MyRectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
    public double Area()
    {
        return Width * Height;
    }
    public MyRectangle(MyRectangle other)
    {
        Width = other.Width;
        Height = other.Height;
    }
    public object Clone()
    {
        return new MyRectangle(this);
    }
}


