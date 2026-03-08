using System;

class Program
{
    static void Main()
    {
        int[] arr1 = { 1, 2, 3, 4 };
        int[] arr2 = { 10, 20, 30, 40 };

        int size1 = arr1.Length;
        int size2 = arr2.Length;

        if (size1 < 0 || size2 < 0)
        {
            Console.WriteLine(-2);
            return;
        }

        foreach (int num in arr1)
        {
            if (num < 0)
            {
                Console.WriteLine(-1);
                return;
            }
        }

        foreach (int num in arr2)
        {
            if (num < 0)
            {
                Console.WriteLine(-1);
                return;
            }
        }

        int size = Math.Min(size1, size2);
        int[] output = new int[size];

        int j = size2 - 1;

        for (int i = 0; i < size; i++)
        {
            output[i] = arr1[i] + arr2[j];
            j--;
        }

        foreach (int val in output)
        {
            Console.Write(val + " ");
        }
    }
}
