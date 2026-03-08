using System;

class Program
{
    static void Main()
    {
        char product = Convert.ToChar(Console.ReadLine());

        double vat = 0;

        switch (product)
        {
            case 'M':
                vat = 5;
                break;
            case 'V':
                vat = 12;
                break;
            case 'C':
                vat = 6.25;
                break;
            case 'D':
                vat = 6;
                break;
            default:
                Console.WriteLine("Invalid Product");
                return;
        }

        Console.WriteLine("VAT = " + vat + "%");
    }
}
