using System;

static class MathOperations
{
    // Add two numbers
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // Add multiple numbers
    public static int Add(params int[] numbers)
    {
        int sum = 0;

        foreach (int num in numbers)
        {
            sum = sum + num;
        }

        return sum;
    }

    // Multiply two numbers
    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    // Multiply multiple numbers
    public static int Multiply(params int[] numbers)
    {
        int product = 1;

        foreach (int num in numbers)
        {
            product = product * num;
        }

        return product;
    }
}

class problem5
{
    static void Main(string[] args)
    {
        Console.WriteLine("Addition of Two Numbers");
        Console.WriteLine(MathOperations.Add(5, 10));

        Console.WriteLine();

        Console.WriteLine("Addition of Multiple Numbers");
        Console.WriteLine(MathOperations.Add(1, 2, 3, 4, 5));

        Console.WriteLine();

        Console.WriteLine("Multiplication of Two Numbers");
        Console.WriteLine(MathOperations.Multiply(2, 3));

        Console.WriteLine();

        Console.WriteLine("Multiplication of Multiple Numbers");
        Console.WriteLine(MathOperations.Multiply(2, 3, 4, 5));
    }
}