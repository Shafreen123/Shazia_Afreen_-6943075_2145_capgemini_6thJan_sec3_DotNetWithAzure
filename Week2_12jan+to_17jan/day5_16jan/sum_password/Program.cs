using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6 };
        int size = arr.Length;
        int output;

        
        if (size < 0)
        {
            output = -2;
        }
        else
        {
            bool hasNegative = false;
            int sumEven = 0;
            int sumOdd = 0;

           
            foreach (int num in arr)
            {
                if (num < 0)
                {
                    hasNegative = true;
                    break;
                }

                if (num % 2 == 0)
                    sumEven += num;
                else
                    sumOdd += num;
            }

            if (hasNegative)
            {
                output = -1;
            }
            else
            {
                
                output = (sumEven + sumOdd) / 2;
            }
        }

        Console.WriteLine(output);
    }
}
