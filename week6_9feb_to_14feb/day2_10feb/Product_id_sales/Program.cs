using System;
using System.Collections.Generic;
using System.Linq;

struct Product
{
    public string ProductID;
    public int TotalSales;
}

class Program
{
    static void Main()
    {
        Dictionary<string, int> products = new Dictionary<string, int>();

        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            string[] parts = line.Split('-');
            string id = parts[0];
            int sale = int.Parse(parts[1]);

            if (products.ContainsKey(id))
            {
                products[id] = Math.Max(products[id], sale);
            }
            else
            {
                products[id] = sale;
            }
        }

        var sorted = products.OrderByDescending(x => x.Value);

        foreach (var item in sorted)
        {
            Console.WriteLine($"{item.Key}-{item.Value}");
        }
    }
}
