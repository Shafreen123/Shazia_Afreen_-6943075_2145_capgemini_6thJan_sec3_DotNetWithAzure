using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter year: ");
        int input = int.Parse(Console.ReadLine());
        int output;

       
        if (input < 0)
        {
            output = -1;
        }
        else
        {
            if ((input % 4 == 0 && input % 100 != 0) || (input % 400 == 0))
                output = 1;   
            else
                output = 0;   
        }

        Console.WriteLine(output);
    }
}
