using System;
using System.Collections.Generic;

public static class LibraryOrderProcessor
{
    public static bool TryParseISBN(string input, out string cleanedISBN)
    {
        cleanedISBN = input.Replace("-", "").Trim();

        if (cleanedISBN.Length == 13)
        {
            return true;
        }

        cleanedISBN = string.Empty;
        return false;
    }

   
    public static bool TryProcessOrder(out List<string> validISBNs, params string[] isbns)
    {
        validISBNs = new List<string>();

        foreach (string isbn in isbns)
        {
            if (TryParseISBN(isbn, out string cleanedISBN))
            {
                validISBNs.Add(cleanedISBN);
            }
        }

        return validISBNs.Count > 0;
    }
}
class Problem2
{
    public static void Main(string[] args)
    {
        bool success = LibraryOrderProcessor.TryProcessOrder(
            out List<string> validBooks,
            "978-3-16-148410-0",
            "1234567890123",
            "invalid-isbn",
            "978-1-4028-9462-6"
        );

        Console.WriteLine($"Order Processed: {success}");

        Console.WriteLine("\nValid ISBNs:");

        foreach (string isbn in validBooks)
        {
            Console.WriteLine(isbn);
        }
    }
}