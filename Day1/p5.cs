using System;
class p5
{
    public static void Main(string[] args)
    {
        double s1, s2, s3, s4, s5;

        s1 = readMark("Subject 1");
        s2 = readMark("Subject 2");
        s3 = readMark("Subject 3");
        s4 = readMark("Subject 4");
        s5 = readMark("Subject 5");

        double total = s1 + s2 + s3 + s4 + s5;
        double average = total / 5;
        double percentage = (total / 500) * 100;

        Console.WriteLine($"Total Marks : {total}");
        Console.WriteLine($"Average     : {Math.Round(average, 2)}");
        Console.WriteLine($"Percentage  : {Math.Round(percentage, 2)}%");
    }

    static double readMark(string subject)
    {
        double mark;

        Console.Write($"Enter {subject} Marks: ");

        while (!double.TryParse(Console.ReadLine(), out mark) || mark < 0 || mark > 100)
        {
            Console.WriteLine("Invalid marks! Enter a value between 0 and 100.");
            Console.Write($"Enter {subject} Marks: ");
        }

        return mark;
    }
}
