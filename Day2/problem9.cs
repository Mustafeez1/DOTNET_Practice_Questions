using System;

class Transaction
{
    public int Id;
    public int Risk;
    public Transaction Next;
}

class problem9
{
    static int CalculateRiskScore(Transaction t, ref int depth)
    {
        if (t == null)
        {
            return 0;
        }

        if (depth > 1000)
        {
            Console.WriteLine("Maximum Depth Reached");
            return -1;
        }

        depth++;

        int score = CalculateRiskScore(t.Next, ref depth);

        if (score == -1)
        {
            return -1;
        }

        return t.Risk + score;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter Transaction Id : ");

        string input = Console.ReadLine();

        int id;

        if (!int.TryParse(input, out id))
        {
            Console.WriteLine("Invalid Transaction Id");
            return;
        }

        Transaction t1 = new Transaction();
        t1.Id = id;
        t1.Risk = 10;

        Transaction t2 = new Transaction();
        t2.Id = 2;
        t2.Risk = 20;

        Transaction t3 = new Transaction();
        t3.Id = 3;
        t3.Risk = 30;

        t1.Next = t2;
        t2.Next = t3;

        int depth = 0;

        int totalRisk = CalculateRiskScore(t1, ref depth);

        Console.WriteLine();

        Console.WriteLine("Total Risk Score : " + totalRisk);
    }
}