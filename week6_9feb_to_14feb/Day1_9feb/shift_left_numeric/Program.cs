using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter alphanumeric string: ");
        string input = Console.ReadLine();

        StringBuilder left = new StringBuilder();   
        StringBuilder right = new StringBuilder();  

        foreach (char ch in input)
        {
            if (char.IsDigit(ch))
                left.Append(ch);
            else
                right.Append(ch);
        }

        Console.WriteLine("Result: " + left.ToString() + right.ToString());
    }
}
