using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine(-2);
            return;
        }

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = int.Parse(Console.ReadLine());

        int sum = 0, count = 0;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] < 0)
            {
                Console.WriteLine(-1);
                return;
            }

            if (arr[i] % 5 == 0)
            {
                sum += arr[i];
                count++;
            }
        }

        if (count == 0)
            Console.WriteLine(0);
        else
            Console.WriteLine(sum / count);
    }
}
