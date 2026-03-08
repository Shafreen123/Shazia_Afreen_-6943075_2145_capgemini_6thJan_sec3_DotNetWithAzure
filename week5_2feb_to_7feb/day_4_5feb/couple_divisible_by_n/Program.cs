using System;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int count = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            if ((arr[i] + arr[i + 1]) % N == 0)
                count++;
        }

        Console.WriteLine(count);
    }
}
