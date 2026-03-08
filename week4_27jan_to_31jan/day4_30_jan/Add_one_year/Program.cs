using System;
using System.Globalization;

class Program
{
    static string FindDayAfterOneYear(string inputDate)
    {
        DateTime date;

        bool isValid = DateTime.TryParseExact(
            inputDate,
            "dd/MM/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out date
        );

        if (!isValid)
        {
            return "Invalid Date Format";
        }

        DateTime newDate = date.AddYears(1);
        return newDate.DayOfWeek.ToString();
    }

    static void Main()
    {
        Console.Write("Enter date (dd/MM/yyyy): ");
        string inputDate = Console.ReadLine();

        string day = FindDayAfterOneYear(inputDate);
        Console.WriteLine("Day after 1 year: " + day);
    }
}
