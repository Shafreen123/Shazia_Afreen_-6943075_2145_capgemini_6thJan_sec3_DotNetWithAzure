using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string invoice = Console.ReadLine();  // CAP-HYD-1234
        string newLocation = Console.ReadLine();  // BAN

        string pattern = @"^(CAP-)([A-Z]+)(-\d+)$";

        string updatedInvoice = Regex.Replace(
            invoice,
            pattern,
            $"$1{newLocation}$3"
        );

        Console.WriteLine(updatedInvoice);
    }
}
