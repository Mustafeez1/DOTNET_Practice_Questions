using System;
using System.Collections.Generic;

class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }
}

class ShoppingCart<T> where T : Product
{
    private List<T> items = new List<T>();

    public void AddItem(T product)
    {
        items.Add(product);
        Console.WriteLine(product.Name + " Added");
    }

    public void RemoveItem(int id)
    {
        foreach (T product in items)
        {
            if (product.Id == id)
            {
                items.Remove(product);
                Console.WriteLine(product.Name + " Removed");
                return;
            }
        }

        Console.WriteLine("Product Not Found");
    }

    public double GetTotalPrice()
    {
        double total = 0;

        foreach (T product in items)
        {
            total += product.Price;
        }

        return total;
    }

    public List<T> GetItems()
    {
        return items;
    }

    // Indexer
    public T this[int index]
    {
        get
        {
            return items[index];
        }
    }
}

static class CartExtension
{
    public static double ApplyDiscount<T>(this ShoppingCart<T> cart, double percent)
        where T : Product
    {
        double total = cart.GetTotalPrice();

        double discount = total * percent / 100;

        return total - discount;
    }
}

class question7
{
    static void Main(string[] args)
    {
        ShoppingCart<Product> cart = new ShoppingCart<Product>();

        cart.AddItem(new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 50000
        });

        cart.AddItem(new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 1000
        });

        cart.AddItem(new Product
        {
            Id = 3,
            Name = "Keyboard",
            Price = 2000
        });

        Console.WriteLine();

        Console.WriteLine("First Product");
        Console.WriteLine(cart[0].Name);

        Console.WriteLine();

        double total = cart.GetTotalPrice();

        double finalAmount = cart.ApplyDiscount(10);

        var invoice = new
        {
            ItemCount = cart.GetItems().Count,
            Total = total,
            Discount = total - finalAmount,
            FinalAmount = finalAmount
        };

        Console.WriteLine();

        Console.WriteLine("Invoice Summary");

        Console.WriteLine("Items : " + invoice.ItemCount);

        Console.WriteLine("Total : ₹" + invoice.Total);

        Console.WriteLine("Discount : ₹" + invoice.Discount);

        Console.WriteLine("Final Amount : ₹" + invoice.FinalAmount);
    }
}