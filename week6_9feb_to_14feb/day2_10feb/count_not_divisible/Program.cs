using System;

class Program
{
    static void Main()
    {
        int[] arr = { 5, 10, 15 }; // change input
        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            bool divisible = false;

            for (int j = 0; j < arr.Length; j++)
            {
                if (i != j && arr[i] % arr[j] == 0)
                {
                    divisible = true;
                    break;
                }
            }

            if (!divisible)
                count++;
        }

        Console.WriteLine(count);
    }
}
