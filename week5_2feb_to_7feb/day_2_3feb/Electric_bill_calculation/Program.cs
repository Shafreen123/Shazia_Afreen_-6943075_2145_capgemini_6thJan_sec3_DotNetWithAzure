using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input1 = Console.ReadLine();   // e.g., AAAAA12345
        string input2 = Console.ReadLine();   // e.g., AAAAA23456
        int rate = int.Parse(Console.ReadLine());

        // Extract numeric parts
        string num1 = Regex.Match(input1, @"\d+").Value;
        string num2 = Regex.Match(input2, @"\d+").Value;

        int reading1 = int.Parse(num1);
        int reading2 = int.Parse(num2);

        int units = Math.Abs(reading2 - reading1);
        int billAmount = units * rate;

        Console.WriteLine(billAmount);
    }
}
