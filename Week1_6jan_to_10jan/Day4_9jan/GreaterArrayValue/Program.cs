using System;

namespace GreaterArrayValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter the size of arrays");
            n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            int[] resultantArray = new int[n];

            Console.WriteLine("Enter the values of first array");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element at index " + i + ": ");
                arr1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the values of second array");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element at index " + i + ": ");
                arr2[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                if (arr1[i] > 0 && arr2[i] > 0)
                {
                    if (arr1[i] > arr2[i])
                        resultantArray[i] = arr1[i];
                    else
                        resultantArray[i] = arr2[i];
                }
                else
                {
                    Console.WriteLine("-1");
                    return;   
                }
            }

           
            Console.WriteLine("Resultant Array:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(resultantArray[i] + " ");
            }
        }
    }
}
