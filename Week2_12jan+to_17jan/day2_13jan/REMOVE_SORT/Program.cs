using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("-1");
            return;
        }

        List<int> list = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int val = Convert.ToInt32(Console.ReadLine());
            if (val >= 0)
                list.Add(val);
        }

        list.Sort();

        foreach (int x in list)
            Console.Write(x + " ");
    }
}
