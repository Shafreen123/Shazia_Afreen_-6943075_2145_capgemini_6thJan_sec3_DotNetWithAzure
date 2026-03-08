using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter first list: ");
        int[] list1 = Console.ReadLine()
                            .Split(',')
                            .Select(int.Parse)
                            .ToArray();

        Console.Write("Enter second list: ");
        int[] list2 = Console.ReadLine()
                            .Split(',')
                            .Select(int.Parse)
                            .ToArray();

        foreach (int n in list1)
        {
            int sum = 0;

            foreach (int x in list2)
            {
                if (x == n)
                    sum += x;
            }

            Console.WriteLine($"{n}-{sum}");
        }
    }
}
