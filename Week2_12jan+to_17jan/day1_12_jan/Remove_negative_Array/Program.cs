using System;

namespace _2nd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of the array");
            int n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                Console.WriteLine("Output is -1");
                return;
            }

            int[] array = new int[n];

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0)
                {
                    n--;

                    for (int j = i; j < n; j++)
                    {
                        array[j] = array[j + 1];
                    }

                    i--; 
                }
            }

            Console.WriteLine("Output array:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
