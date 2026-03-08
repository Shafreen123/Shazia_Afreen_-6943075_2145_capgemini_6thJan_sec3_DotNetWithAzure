using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine(-1);
            return;
        }

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
            if (arr[i] >= 0)
                list.Add(arr[i]);

        list.Sort();

        foreach (int x in list)
            Console.Write(x + " ");
    }
}
