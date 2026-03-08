using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of lines: ");
        int N = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();

            int posThe = line.IndexOf("the");
            int posOf = line.IndexOf("of");

            Console.WriteLine(posThe + " " + posOf);
        }
    }
}
