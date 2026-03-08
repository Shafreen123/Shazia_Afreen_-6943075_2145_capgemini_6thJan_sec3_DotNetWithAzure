using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a decimal number: ");
        int input1 = int.Parse(Console.ReadLine());

       
        if (input1 < 0)
        {
            Console.WriteLine(-1);
            return;
        }

       
        if (input1 == 0)
        {
            Console.WriteLine("0");
            return;
        }

        int[] binary = new int[32];
        int index = 0;

        while (input1 > 0)
        {
            binary[index++] = input1 % 2;
            input1 = input1 / 2;
        }

        for (int i = index - 1; i >= 0; i--)
        {
            Console.Write(binary[i] + " ");
        }
    }
}
