using System;
using System.Collections.Generic;

// Partial Class - Part 1
public partial class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsAvailable { get; set; }
}

// Partial Class - Part 2
public partial class Book
{
    public void Display()
    {
        Console.WriteLine(Id + " - " + Title);
    }
}

// Generic Repository
class LibraryRepository<T> where T : Book
{
    private List<T> books = new List<T>();

    public void Add(T book)
    {
        books.Add(book);
    }

    public void Borrow(string title)
    {
        foreach (T book in books)
        {
            if (book.Title == title && book.IsAvailable)
            {
                book.IsAvailable = false;
                Console.WriteLine("Book Borrowed Successfully");
                return;
            }
        }

        Console.WriteLine("Book Not Available");
    }

    public void Return(string title)
    {
        foreach (T book in books)
        {
            if (book.Title == title)
            {
                book.IsAvailable = true;
                Console.WriteLine("Book Returned Successfully");
                return;
            }
        }

        Console.WriteLine("Book Not Found");
    }

    public T Search(string title)
    {
        foreach (T book in books)
        {
            if (book.Title == title)
            {
                return book;
            }
        }

        return null;
    }

    public List<T> GetBooks()
    {
        return books;
    }

    // Indexer
    public T this[string title]
    {
        get
        {
            return Search(title);
        }
    }
}

// Extension Method
static class LibraryExtension
{
    public static void GetAvailableBooks<T>(this LibraryRepository<T> library)
        where T : Book
    {
        Console.WriteLine("Available Books");

        foreach (T book in library.GetBooks())
        {
            if (book.IsAvailable)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}

class question5
{
    static void Main(string[] args)
    {
        LibraryRepository<Book> library = new LibraryRepository<Book>();

        library.Add(new Book
        {
            Id = 1,
            Title = "Clean Code",
            IsAvailable = true
        });

        library.Add(new Book
        {
            Id = 2,
            Title = "C# Programming",
            IsAvailable = true
        });

        library.Add(new Book
        {
            Id = 3,
            Title = "ASP.NET Core",
            IsAvailable = true
        });

        Console.WriteLine("Search Book");
        Book book = library["Clean Code"];

        if (book != null)
        {
            book.Display();
        }

        Console.WriteLine();

        library.Borrow("Clean Code");

        Console.WriteLine();

        library.GetAvailableBooks();

        Console.WriteLine();

        library.Return("Clean Code");

        Console.WriteLine();

        library.GetAvailableBooks();
    }
}