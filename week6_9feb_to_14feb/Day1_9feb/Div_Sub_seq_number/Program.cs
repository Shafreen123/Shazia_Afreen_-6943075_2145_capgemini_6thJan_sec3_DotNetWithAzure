using System;

class Program
{
    static int CountCouples(int N, int[] arr)
    {
        int count = 0;

        for (int i = 0; i < N - 1; i++)
        {
            int sum = arr[i] + arr[i + 1];

            if (sum % N == 0)
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        
        int N1 = 4;
        int[] arr1 = { 2, 2, 4, 0 };
        Console.WriteLine(CountCouples(N1, arr1)); 

       
        int N2 = 5;
        int[] arr2 = { 1, 2, 3, 4, 5 };
        Console.WriteLine(CountCouples(N2, arr2));  
    }
}
