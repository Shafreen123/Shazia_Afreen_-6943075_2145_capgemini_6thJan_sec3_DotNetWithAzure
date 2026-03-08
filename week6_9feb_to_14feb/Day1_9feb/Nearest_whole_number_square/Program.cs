using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer (1 to 7 digits): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number) && number > 0 && input.Length <= 7)
        {
            double sqrt = Math.Sqrt(number);

            int lower = (int)Math.Floor(sqrt);
            int upper = (int)Math.Ceiling(sqrt);

            int lowerSquare = lower * lower;
            int upperSquare = upper * upper;

           
            int closestSquare = (number - lowerSquare <= upperSquare - number)
                                ? lowerSquare
                                : upperSquare;

            Console.WriteLine("Closest number with whole number square root: " + closestSquare);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer up to 7 digits.");
        }
    }
}
