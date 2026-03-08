using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 4, 5 }; 

        int n = arr.Length + 1;

        int expectedSum = n * (n + 1) / 2;
        int actualSum = arr.Sum();

        Console.WriteLine("Missing number: " + (expectedSum - actualSum));
    }
}
