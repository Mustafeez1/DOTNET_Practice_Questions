using System;
interface IInvestmentCalculator
{
    double CalculateReturn(double principal, double rate, double years);
}

class SimpleInterestCalculator : IInvestmentCalculator
{
    public double CalculateReturn(double principal, double rate, double years)
    {
        double interest = (principal * rate * years) / 100;
        return principal + interest;
    }
}

class CompoundInterestCalculator : IInvestmentCalculator
{
    public double CalculateReturn(double principal, double rate, double years)
    {
        return principal * Math.Pow((1 + rate / 100), years);
    }
}
class p10
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Investment Type (Simple/Compound): ");
        string investmentType = Console.ReadLine();

        double principal, rate, years;

        Console.Write("Enter Principal Amount: ");
        while (!double.TryParse(Console.ReadLine(), out principal) || principal <= 0)
        {
            Console.WriteLine("Invalid amount! Enter a positive number.");
            Console.Write("Enter Principal Amount: ");
        }

        Console.Write("Enter Annual Interest Rate (%): ");
        while (!double.TryParse(Console.ReadLine(), out rate) || rate < 0 || rate > 100)
        {
            Console.WriteLine("Invalid rate! Enter a value between 0 and 100.");
            Console.Write("Enter Annual Interest Rate (%): ");
        }

        Console.Write("Enter Duration (Years): ");
        while (!double.TryParse(Console.ReadLine(), out years) || years <= 0)
        {
            Console.WriteLine("Invalid duration! Enter a positive number.");
            Console.Write("Enter Duration (Years): ");
        }

        IInvestmentCalculator calculator;

        if (investmentType.Equals("Simple", StringComparison.OrdinalIgnoreCase))
        {
            calculator = new SimpleInterestCalculator();
        }
        else if (investmentType.Equals("Compound", StringComparison.OrdinalIgnoreCase))
        {
            calculator = new CompoundInterestCalculator();
        }
        else
        {
            Console.WriteLine("Invalid Investment Type.");
            return;
        }

        double finalAmount = calculator.CalculateReturn(principal, rate, years);

        
        Console.WriteLine($"Investment Type : {investmentType}");
        Console.WriteLine($"Principal       : ₹{principal}");
        Console.WriteLine($"Interest Rate   : {rate}%");
        Console.WriteLine($"Duration        : {years} years");
        Console.WriteLine($"Final Amount    : ₹{Math.Round(finalAmount, 2)}");
    }
}