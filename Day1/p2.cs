using System;
class Program
{
    public static void Main(string[] args)
    {
        double weight;
        double height;

        Console.WriteLine("Enter weight");
        while(!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
        {
            Console.WriteLine("Invalid weight! Please enter a positive number.");
            Console.Write("Enter Weight (kg): ");
        }

        Console.WriteLine("Enter Height");
        while(!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            Console.WriteLine("Invalid height! Please enter a positive number.");
            Console.Write("Enter height: ");
        }

        double bmi = weight / (height * height);

        Console.WriteLine($"BMI: {Math.Round(bmi, 2)}");

        if (bmi < 18.5)
        {
            Console.WriteLine("Category: Underweight");
        }
        else if (bmi < 25)
        {
            Console.WriteLine("Category: Normal Weight");
        }
        else if (bmi < 30)
        {
            Console.WriteLine("Category: Overweight");
        }
        else
        {
            Console.WriteLine("Category: Obese");
        }
    }
}