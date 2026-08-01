using System;
class Program
{
    public static void Main(string[] args)
    {
        double price;
        int quantity;
        double discount;
        Console.WriteLine("Enter Price");
        while(!double.TryParse(Console.ReadLine(), out price) ||  price < 0)
        {
            Console.WriteLine("Invalid price! Please enter a valid positive number.");
            Console.Write("Enter Item Price: ");
        }

        Console.WriteLine("Enter Quantity");
        while(!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity! Please enter a valid positive number.");
            Console.Write("Enter Item quantity: ");
        }

        Console.WriteLine("Enter discount");
        while(!double.TryParse(Console.ReadLine(), out discount) || discount < 0 || discount > 100)
        {
            Console.WriteLine("Invalid discount! Please enter a valid positive number.");
            Console.Write("Enter Item discount: ");
        }

        double subtotal = price * quantity;
        double dicountAmount = subtotal * discount/100;
        double finalAmount = subtotal - discountAmount;


        Console.WriteLine($"Subtotal         : {Math.Round(subtotal, 2)}");
        Console.WriteLine($"Discount Amount  : {Math.Round(discountAmount, 2)}");
        Console.WriteLine($"Final Amount     : {Math.Round(finalAmount, 2)}");
    }
}