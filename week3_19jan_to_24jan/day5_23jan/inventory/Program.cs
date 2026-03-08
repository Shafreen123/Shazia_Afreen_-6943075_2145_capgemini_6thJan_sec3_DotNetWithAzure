using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

class Program
{
    static void Main()
    {
        List<Book> inventory = new List<Book>
        {
            new Book { Title = "C# Basics", Price = 500, Stock = 10 },
            new Book { Title = "LINQ in Action", Price = 750, Stock = 0 },
            new Book { Title = "Data Structures", Price = 650, Stock = 5 }
        };

       
        inventory.Add(new Book { Title = "Algorithms", Price = 400, Stock = 8 });

       
        double targetPrice = 600;
        var cheapBooks = inventory.Where(b => b.Price < targetPrice);

        Console.WriteLine("Books cheaper than " + targetPrice);
        foreach (var book in cheapBooks)
            Console.WriteLine(book.Title);

       
        inventory = inventory
            .Select(b =>
            {
                b.Price += b.Price * 0.10;
                return b;
            })
            .ToList();

        
        inventory.RemoveAll(b => b.Stock == 0);

        Console.WriteLine("\nFinal Inventory:");
        foreach (var book in inventory)
            Console.WriteLine($"{book.Title} - ₹{book.Price} - Stock: {book.Stock}");
    }
}
