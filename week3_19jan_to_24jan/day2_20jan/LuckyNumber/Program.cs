using System;

namespace LuckyNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int x = int.Parse(Console.ReadLine());

            int square = x * x;

            // Sum of digits of x^2
            int reminder = square;
            int sum = 0;
            while (reminder > 0)
            {
                int digit = reminder % 10;
                sum = sum + digit;
                reminder = reminder / 10;
            }

           
            int y = x;
            int sumx = 0;
            while (y > 0)
            {
                int digitx = y % 10;
                sumx = sumx + digitx;
                y = y / 10;
            }

            if (sum == sumx * sumx)
            {
                Console.WriteLine(x + " is a lucky number");
            }
            else
            {
                Console.WriteLine(x + " is not a lucky number");
            }
        }
    }
}
