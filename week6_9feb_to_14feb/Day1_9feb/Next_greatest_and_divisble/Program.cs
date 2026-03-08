using System;

class Program
{
    static int CountElements(int[] arr)
    {
        int n = arr.Length;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] > arr[i] && arr[j] % arr[i] == 0)
                {
                    count++;
                    break; 
                }
            }
        }

        return count;
    }

    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int N = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[N];

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < N; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int result = CountElements(arr);

        Console.WriteLine("Count: " + result);
    }
}
