using system;
class p4
{
    public static void Main(string[] args)
    {
        double openingBalance, withdrawals, deposits;
        Console.Write("Enter Opening Balance: ");
        while (!double.TryParse(Console.ReadLine(), out openingBalance) || openingBalance < 0)
        {
            Console.WriteLine("Invalid opening balance Please enter a non-negative number.");
            Console.Write("Enter Opening Balance: ");
        }

        Console.Write("Enter Total Deposits: ");
        while (!double.TryParse(Console.ReadLine(), out deposits) || deposits < 0)
        {
            Console.WriteLine("Invalid deposit Please enter a non-negative number.");
            Console.Write("Enter Total Deposits: ");
        }

        Console.Write("Enter Total Withdrawals: ");
        while (!double.TryParse(Console.ReadLine(), out withdrawals) || withdrawals < 0)
        {
            Console.WriteLine("Invalid withdrawal Please enter a non-negative number.");
            Console.Write("Enter Total Withdrawals: ");
        }

        double finalAmount = openingBalance + deposits;
        if(withdrawals > finalAmount)
        {
            Console.WriteLine("Withdrawal amount exceeds final amount");
        }
        finalAmount = finalAmount - withdrawals;
        Console.WriteLine($"Opening Balance : {openingBalance}");
        Console.WriteLine($"Deposits        : {deposits}");
        Console.WriteLine($"Withdrawals     : {withdrawals}");
        Console.WriteLine($"Final Balance   : {Math.Round(finalBalance, 2)}");
    }
}