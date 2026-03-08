using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int root = (int)Math.Sqrt(n);

        int lowerSquare = root * root;
        int upperSquare = (root + 1) * (root + 1);

        int result = (n - lowerSquare <= upperSquare - n)
                     ? lowerSquare
                     : upperSquare;

        Console.WriteLine(result);
    }
}
