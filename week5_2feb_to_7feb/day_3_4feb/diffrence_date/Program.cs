using System;

class Program
{
    static void Main()
    {
        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine();

        DateTime date1 = DateTime.ParseExact(input1, "dd/MM/yyyy", null);
        DateTime date2 = DateTime.ParseExact(input2, "dd/MM/yyyy", null);

        int days = Math.Abs((date2 - date1).Days);

        Console.WriteLine(days + " days");
    }
}
