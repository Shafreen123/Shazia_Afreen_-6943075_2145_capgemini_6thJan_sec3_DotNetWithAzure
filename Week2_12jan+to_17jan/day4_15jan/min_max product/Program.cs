using System;

class Program
{
    static void Main()
    {
        int[] arr = { 2, 5, 8, 1, 6 };
        int size = arr.Length;
        int output;
        if (size < 0)
        {
            output = -2;
        }
        else
        {
            bool hasNegative = false;

            foreach (int num in arr)
            {
                if (num < 0)
                {
                    hasNegative = true;
                    break;
                }
            }

           
            if (hasNegative)
            {
                output = -1;
            }
            else
            {
                int max = arr[0];
                int min = arr[0];

                for (int i = 1; i < size; i++)
                {
                    if (arr[i] > max)
                        max = arr[i];

                    if (arr[i] < min)
                        min = arr[i];
                }

                output = max * min;
            }
        }

        Console.WriteLine(output);
    }
}
