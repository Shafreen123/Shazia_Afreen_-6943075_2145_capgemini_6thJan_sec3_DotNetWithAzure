using System;

namespace PrimeCubeSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int output;

            if (n < 0)
            {
                output = -1;
                Console.WriteLine(output);
                return;
            }

            if (n > 32676)
            {
                output = -2;
                Console.WriteLine(output);
                return;
            }

            long sum = 0;

            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;

                for (int j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    sum += (long)i * i * i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
