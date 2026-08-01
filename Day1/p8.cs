using System;
class p8
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Package Type (Standard/Express): ");
        string packageType = Console.ReadLine();

        double weight;
        double distance;

        Console.Write("Enter Weight : ");
        while (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
        {
            Console.WriteLine("Invalid weight! Enter a positive number.");
            Console.Write("Enter Weight: ");
        }

        Console.Write("Enter Distance (km): ");
        while (!double.TryParse(Console.ReadLine(), out distance) || distance <= 0)
        {
            Console.WriteLine("Invalid distance! Enter a positive number.");
            Console.Write("Enter Distance (km): ");
        }

        IShippingCalculator shippingCalculator;

        if (packageType.Equals("Standard", StringComparison.OrdinalIgnoreCase))
        {
            shippingCalculator = new StandardShipping();
        }
        else if (packageType.Equals("Express", StringComparison.OrdinalIgnoreCase))
        {
            shippingCalculator = new ExpressShipping();
        }
        else
        {
            Console.WriteLine("Invalid Package Type.");
            return;
        }

        double shippingCost = shippingCalculator.CalculateShippingCost(weight, distance);

        
        Console.WriteLine($"Package Type : {packageType}");
        Console.WriteLine($"Weight       : {weight} kg");
        Console.WriteLine($"Distance     : {distance} km");
        Console.WriteLine($"Shipping Cost: ₹{Math.Round(shippingCost, 2)}");
    }
}
interface IShippingCalculator
{
    double CalculateShippingCost(double weight, double distance);
}

class StandardShipping : IShippingCalculator
{
    public double CalculateShippingCost(double weight, double distance)
    {
        return weight * distance * 2;
    }
}

class ExpressShipping : IShippingCalculator
{
    public double CalculateShippingCost(double weight, double distance)
    {
        return (weight * distance * 3.5) + 100;
    }
}
