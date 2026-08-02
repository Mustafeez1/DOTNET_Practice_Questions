using System;

class problem4
{
    // Circle
    static double CalculateArea(double radius, int decimals = 2)
    {
        double area = 3.14159 * radius * radius;
        return Math.Round(area, decimals);
    }

    // Rectangle
    static double CalculateArea(int length, int width)
    {
        return length * width;
    }

    // Triangle
    static double CalculateArea(double baseValue, double height)
    {
        return 0.5 * baseValue * height;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Area of Circle");
        Console.WriteLine(CalculateArea(5));

        Console.WriteLine();

        Console.WriteLine("Area of Rectangle");
        Console.WriteLine(CalculateArea(4, 6));

        Console.WriteLine();

        Console.WriteLine("Area of Triangle");
        Console.WriteLine(CalculateArea(3.0, 7.0));

        Console.WriteLine();

        Console.WriteLine("Circle Area with Named Argument");
        Console.WriteLine(CalculateArea(radius: 5, decimals: 4));
    }
}