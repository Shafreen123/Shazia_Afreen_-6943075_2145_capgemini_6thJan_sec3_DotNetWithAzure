using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer (1 to 10 digits): ");
        string input = Console.ReadLine();

        
        if (long.TryParse(input, out long number) && number >= 0 && input.Length <= 10)
        {
            int sum = 0;

            foreach (char digit in input)
            {
                sum += digit - '0';
            }

            Console.WriteLine("Sum of digits: " + sum);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer with up to 10 digits.");
        }
    }
}
