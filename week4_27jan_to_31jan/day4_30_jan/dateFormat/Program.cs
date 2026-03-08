using System;
using System.Globalization;

class Program
{
    static string AddYearsToDate(string inputDate, int years)
    {
        if (years < 0)
        {
            return "-2";
        }

        DateTime date;
        bool isValid = DateTime.TryParseExact(
            inputDate,
            "dd-MM-yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out date
        );

        if (!isValid)
        {
            return "-1";
        }

        DateTime newDate = date.AddYears(years);
        return newDate.ToString("dd-MM-yyyy");
    }

    static void Main()
    {
        Console.Write("Enter date (dd-MM-yyyy): ");
        string date = Console.ReadLine();

        Console.Write("Enter years to add: ");
        int years = int.Parse(Console.ReadLine());

        string result = AddYearsToDate(date, years);
        Console.WriteLine("Output: " + result);
    }
}
