using System;

class Program
{
    static string InsertSubstring(string original, string toInsert, int position)
    {
        
        if (position < 0 || position > original.Length)
        {
            Console.WriteLine("Invalid position.");
            return original;
        }

        string result = original.Substring(0, position)
                        + toInsert
                        + original.Substring(position);

        return result;
    }

    static void Main()
    {
        Console.Write("Enter main string: ");
        string mainStr = Console.ReadLine();

        Console.Write("Enter substring to insert: ");
        string subStr = Console.ReadLine();

        Console.Write("Enter position: ");
        int pos = Convert.ToInt32(Console.ReadLine());

        string result = InsertSubstring(mainStr, subStr, pos);

        Console.WriteLine("Result: " + result);
    }
}
