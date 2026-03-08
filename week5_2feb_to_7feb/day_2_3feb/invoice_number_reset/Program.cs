using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string invoice = Console.ReadLine();  // CAP-123
        int increment = int.Parse(Console.ReadLine());

        Match match = Regex.Match(invoice, @"CAP-(\d+)");

        if (match.Success)
        {
            int number = int.Parse(match.Groups[1].Value);
            int newNumber = number + increment;

            string updatedInvoice = Regex.Replace(invoice, @"\d+", newNumber.ToString());

            Console.WriteLine(updatedInvoice);
        }
    }
}
