using System;
class p3
{
    public static void Main(string[] args)
    {
        double length;
        double width;
        double height;
        Console.WriteLine("Enter length");
        while(!double.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.WriteLine("Invalid length Please enter a positive number");
            Console.WriteLine("Enter Item length");
        }

        Console.WriteLine("Enter width");
        while(!double.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.WriteLine("Invalid width Please enter a positive number");
            Console.WriteLine("Enter Item width");
        }

        Console.WriteLine("Enter height");
        while(!double.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.WriteLine("Invalid height Please enter a positive number");
            Console.WriteLine("Enter Item height");
        }

        double volume = length * width * height;

        Console.WriteLine($"Volume : {Math.Round(volume, 2)} units");
    }
}