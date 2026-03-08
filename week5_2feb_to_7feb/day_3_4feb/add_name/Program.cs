using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"^Hi how are you Dear [A-Za-z]{16,}$";

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("Valid");
        else
            Console.WriteLine("Invalid");
    }
}
