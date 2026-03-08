using System;

class Program
{
    static void Main()
    {
        int input1, input2;
        int output = 0;

      
        Console.Write("Enter input1: ");
        input1 = int.Parse(Console.ReadLine());

        Console.Write("Enter input2: ");
        input2 = int.Parse(Console.ReadLine());

       
        if (input1 < 0)
        {
            output = -1;
        }
        else if (input2 > 32627)
        {
            output = -2;
        }
        else
        {
            
            for (int i = input1; i <= input2; i += input1)
            {
                output += i;
            }
        }

        Console.WriteLine("Output: " + output);
    }
}
