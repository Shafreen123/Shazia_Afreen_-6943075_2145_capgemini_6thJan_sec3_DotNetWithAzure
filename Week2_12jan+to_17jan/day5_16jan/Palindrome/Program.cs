using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine());
        int output;

        if (input < 0)
        {
            output = -1;
        }
        else
        {
            int original = input;
            int reverse = 0;

            while (input > 0)
            {
                int digit = input % 10;
                reverse = reverse * 10 + digit;
                input = input / 10;
            }

            
            if (original == reverse)
                output = 1;    
            else
                output = -2;   
        }

        Console.WriteLine(output);
    }
}
