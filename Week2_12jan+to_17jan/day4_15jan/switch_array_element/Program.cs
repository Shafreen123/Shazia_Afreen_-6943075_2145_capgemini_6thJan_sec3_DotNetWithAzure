using System;

namespace switch_array_element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input3;
            int output = 0;

            Console.WriteLine("Enter the size of array");
            input3 = int.Parse(Console.ReadLine());

            if (input3 < 0)
            {
                output = -1;
                Console.WriteLine(output);
                return;
            }

            int[] input1 = new int[input3];
            int[] input2 = new int[input3];

            Console.WriteLine("Enter first array values");
            for (int i = 0; i < input3; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter second array values");
            for (int i = 0; i < input3; i++)
            {
                input2[i] = int.Parse(Console.ReadLine());
            }

            int[] output1 = new int[input3];
            int n = input3 - 1;

            for (int i = 0; i < input3; i++)
            {
               
                if (input1[i] < 0 || input2[n] < 0)
                {
                    output = -2;
                    Console.WriteLine(output);
                    return;
                }

                output1[i] = input1[i] + input2[n];
                n--;
            }

            Console.WriteLine("Output is:");
            Console.Write("{");
            for (int i = 0; i < input3; i++)
            {
                Console.Write(output1[i]+",");
            }
            Console.Write("}");
        }
    }
}
