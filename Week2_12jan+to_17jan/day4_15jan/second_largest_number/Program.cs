using System;

namespace SecondLargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input3;
            int output1 = 0;

            Console.WriteLine("Enter size of array");
            input3 = int.Parse(Console.ReadLine());

           
            if (input3 < 0)
            {
                output1 = -2;
                Console.WriteLine(output1);
                return;
            }

            int[] input1 = new int[input3];

            Console.WriteLine("Enter array elements");
            for (int i = 0; i < input3; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());

                if (input1[i] < 0)
                {
                    output1 = -1;
                    Console.WriteLine(output1);
                    return;
                }
            }

            
            Array.Sort(input1);
            Array.Reverse(input1);

            
            output1 = input1[1];

            Console.WriteLine("Second largest element is:");
            Console.WriteLine(output1);
        }
    }
}
