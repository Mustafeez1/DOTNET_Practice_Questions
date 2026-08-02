class FinancialCalculatorP1
{
    public static double CalculateCompoundInterest(
        double principal,
        double rate,
        int time = 1,
        int compoundingFrequency = 1)
    {
        return principal *
               Math.Pow(1 + rate / compoundingFrequency,
                        compoundingFrequency * time);
    }

    
    public static double CalculateCompoundInterest(
        double principal,
        double rate,
        int time)
    {
        return CalculateCompoundInterest(principal, rate, time, 1);
    }
}
class P1
{
    public static void Main(string[] args)
    {
        double futureValue1 =
            FinancialCalculator.CalculateCompoundInterest(10000, 0.05, 10);

        double futureValue2 =
            FinancialCalculator.CalculateCompoundInterest(
                principal: 10000,
                rate: 0.05,
                time: 10,
                compoundingFrequency: 12);

        Console.WriteLine("Annual Compounding");
        Console.WriteLine(Math.Round(futureValue1,2));

        Console.WriteLine();

        Console.WriteLine("Monthly Compounding");
        Console.WriteLine(Math.Round(futureValue2,2));
    }
}