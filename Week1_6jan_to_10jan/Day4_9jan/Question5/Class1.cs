using System;
using System.Collections.Generic;
using System.Text;

namespace Question5
{
    internal class Class1
    {
        static int[] ProcessArrays(int[] arr1, int[] arr2)
        {
            int n = arr1.Length;
            int[] output = new int[n];
            if (n < 0 || arr2.Length < 0)
            {
                output[0] = -2;
                return output;
            }


            for (int i = 0; i < n; i++)
            {
                if (arr1[i] < 0 || arr2[i] < 0)
                {
                    output[0] = -1;
                    return output;
                }
            }

            Array.Sort(arr1);

            Array.Sort(arr2);
            Array.Reverse(arr2);

            for (int i = 0; i < n; i++)
            {
                output[i] = arr1[i] * arr2[n - 1 - i];
            }

            return output;
        }

        static void Main()
        {
            int[] input1 = { 1, 2, 3, 4, 5 };
            int[] input2 = { 9, 8, 7, 6, 5 };

            int[] result = ProcessArrays(input1, input2);

            Console.WriteLine("Output:");
            foreach (int val in result)
            {
                Console.Write(val + " ");
            }

        }
    }
}
