using System;

class Program
{
    static int CountTripleConsecutive(string input)
    {
        int count = 0;

        for (int i = 0; i < input.Length - 2; i++)
        {
            if (input[i] == input[i + 1] && input[i] == input[i + 2])
            {
                count++;
               
                i += 2;
            }
        }

        return count;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input1 = Console.ReadLine();

        int result = CountTripleConsecutive(input1);
        Console.WriteLine("Output1 = " + result);
    }
}
