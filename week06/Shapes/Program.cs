using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // One list that holds different kinds of shapes.
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 3));
        shapes.Add(new Rectangle("Blue", 4, 5));
        shapes.Add(new Circle("Green", 2));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();

            // The same line calls a different GetArea() for each type of shape.
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}
