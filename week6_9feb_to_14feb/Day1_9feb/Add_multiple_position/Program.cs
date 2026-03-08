using System;
using System.Collections.Generic;

class Program
{
    static string InsertMultiple(string original, List<(int position, string text)> inserts)
    {
        
        inserts.Sort((a, b) => a.position.CompareTo(b.position));

        int offset = 0;

        foreach (var item in inserts)
        {
            int pos = item.position + offset;

            if (pos < 0 || pos > original.Length)
                continue; 

            original = original.Insert(pos, item.text);

            offset += item.text.Length; 
        }

        return original;
    }

    static void Main()
    {
        string original = "ABCDEF";

        var inserts = new List<(int, string)>
        {
            (0, "Hello"),
            (5, "World"),
            (original.Length, "!")
        };

        string result = InsertMultiple(original, inserts);

        Console.WriteLine("Final String: " + result);
    }
}
