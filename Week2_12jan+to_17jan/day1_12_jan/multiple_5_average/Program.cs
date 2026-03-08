using System;

namespace SumAndAvgMultiples5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 0)
            {
                Console.WriteLine(-2);
                return;
            }

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] < 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            int sum = 0;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 5 == 0)
                {
                    sum += arr[i];
                    count++;
                }
            }

            double avg = count > 0 ? (double)sum / count : 0;
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + avg);
        }
    }
}
