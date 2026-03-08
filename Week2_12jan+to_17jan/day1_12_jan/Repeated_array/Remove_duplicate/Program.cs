using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("enter length of array");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter Element");

        for (int i = 0; i < n; i++)
            arr[i] = int.Parse(Console.ReadLine());

        int[] output = new int[n];

        for (int i = 0; i < n; i++)
            if (arr[i] < 0)
            {
                output[0] = -1;
                Console.WriteLine(output[0]);
                return;
            }

        HashSet<int> set = new HashSet<int>(arr);
        set.CopyTo(output);

        foreach (int x in set)
            Console.Write(x + " ");
    }
}
