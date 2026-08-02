using System;
using System.Collections.Generic;

class InvalidKeyException : Exception
{
    public InvalidKeyException(string message) : base(message)
    {
    }
}

class CacheManager<T>
{
    private Dictionary<string, T> cache = new Dictionary<string, T>();

    public void Add(string key, T value)
    {
        cache[key] = value;
    }

    public void Remove(string key)
    {
        if (cache.ContainsKey(key))
        {
            cache.Remove(key);
        }
        else
        {
            throw new InvalidKeyException("Key Not Found");
        }
    }

    public T GetByKey(string key)
    {
        if (cache.ContainsKey(key))
        {
            return cache[key];
        }

        throw new InvalidKeyException("Key Not Found");
    }

    public void Clear()
    {
        cache.Clear();
    }

    public T this[string key]
    {
        get
        {
            return GetByKey(key);
        }
    }

    public Dictionary<string, T> GetCache()
    {
        return cache;
    }
}

static class CacheExtension
{
    public static void GetAllKeys<T>(this CacheManager<T> manager)
    {
        foreach (var item in manager.GetCache())
        {
            Console.WriteLine(item.Key);
        }
    }

    public static int CountItems<T>(this CacheManager<T> manager)
    {
        return manager.GetCache().Count;
    }
}

class Customer
{
    public int Id;
    public string Name;
}

class question2
{
    static void Main()
    {
        CacheManager<Customer> cache = new CacheManager<Customer>();

        Customer c1 = new Customer();
        c1.Id = 1;
        c1.Name = "Rahul";

        Customer c2 = new Customer();
        c2.Id = 2;
        c2.Name = "Amit";

        cache.Add("C1", c1);
        cache.Add("C2", c2);

        Console.WriteLine("Customer Name");
        Console.WriteLine(cache["C1"].Name);

        Console.WriteLine();

        Console.WriteLine("Total Items");
        Console.WriteLine(cache.CountItems());

        Console.WriteLine();

        Console.WriteLine("All Keys");

        cache.GetAllKeys();

        cache.Remove("C2");

        Console.WriteLine();

        Console.WriteLine("Items After Remove");
        Console.WriteLine(cache.CountItems());
    }
}