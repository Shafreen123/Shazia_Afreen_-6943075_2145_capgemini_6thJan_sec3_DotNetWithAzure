using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static string RemoveDuplicates(string input)
    {
        HashSet<char> seen = new HashSet<char>();
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            
            if (!seen.Contains(c))
            {
                result.Append(c);
               
                if (c != ' ')
                    seen.Add(c);
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input1 = Console.ReadLine();

        string output = RemoveDuplicates(input1);
        Console.WriteLine("Output: " + output);
    }
}
