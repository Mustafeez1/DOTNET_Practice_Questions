using System;
class p6
{
    public static void Main(string[] args)
    {
        double unitsConsumed, ratePerUnit, fixedCharges;
        Console.Write("Enter Customer Type (Residential/Commercial): ");
        string customerType = Console.ReadLine();

        Console.Write("Enter Units Consumed: ");
        while (!double.TryParse(Console.ReadLine(), out units) || units < 0)
        {
            Console.Write("Invalid! Enter Units Again: ");
        }

        Console.Write("Enter Rate per Unit: ");
        while (!double.TryParse(Console.ReadLine(), out rate) || rate < 0)
        {
            Console.Write("Invalid! Enter Rate Again: ");
        }

        Console.Write("Enter Fixed Charges: ");
        while (!double.TryParse(Console.ReadLine(), out fixedCharges) || fixedCharges < 0)
        {
            Console.Write("Invalid! Enter Fixed Charges Again: ");
        }

        IBillCalculator billCalculator;

        if (customerType.Equals("Residential", StringComparison.OrdinalIgnoreCase))
        {
            billCalculator = new ResidentialBill();
        }
        else if (customerType.Equals("Commercial", StringComparison.OrdinalIgnoreCase))
        {
            billCalculator = new CommercialBill();
        }
        else
        {
            Console.WriteLine("Invalid Customer Type.");
            return;
        }

        double totalBill = billCalculator.CalculateBill(units, rate, fixedCharges);
        Console.WriteLine($"Customer Type : {customerType}");
        Console.WriteLine($"Units         : {units}");
        Console.WriteLine($"Rate          : ₹{rate}");
        Console.WriteLine($"Fixed Charges : ₹{fixedCharges}");
        Console.WriteLine($"Total Bill    : ₹{Math.Round(totalBill, 2)}");

    }
}


interface IBillCalculator
{
    double CalculateBill(double units, double rate, double fixedCharges);
}

class ResidentialBill : IBillCalculator
{
    public double CalculateBill(double units, double rate, double fixedCharges)
    {
        return (units * rate) + fixedCharges;
    }
}

class CommercialBill : IBillCalculator
{
    public double CalculateBill(double units, double rate, double fixedCharges)
    {
        return ((units * rate) * 1.15) + fixedCharges;
    }
}