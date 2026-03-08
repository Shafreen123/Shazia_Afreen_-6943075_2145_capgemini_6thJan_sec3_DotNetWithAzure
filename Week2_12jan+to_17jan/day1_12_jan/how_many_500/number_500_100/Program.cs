using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("enter value");
        int amount = int.Parse(Console.ReadLine());
        if (amount < 0)
        {
            Console.WriteLine(-1);
            return;
        }

        int count = 0;
        int[] notes = { 500, 100, 50, 10, 1 };

        for (int i = 0; i < notes.Length; i++)
        {
            count += amount / notes[i];
            amount %= notes[i];
        }

        Console.WriteLine(count);
    }
}
