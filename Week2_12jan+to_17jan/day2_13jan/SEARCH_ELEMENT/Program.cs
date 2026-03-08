using System;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("-2");
            return;
        }

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
            if (arr[i] < 0)
            {
                Console.WriteLine("-1");
                return;
            }
        }

        int search = Convert.ToInt32(Console.ReadLine());
        bool found = false;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] == search)
            {
                found = true;
                break;
            }
        }

        if (found)
            Console.WriteLine("1");
        else
            Console.WriteLine("-3");
    }
}
