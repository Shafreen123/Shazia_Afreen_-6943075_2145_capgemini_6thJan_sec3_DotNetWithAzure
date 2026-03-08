using System;

class Program
{
    static string ReplaceSubstring(string original, string toRemove, string toInsert)
    {
        int index = original.IndexOf(toRemove);

        if (index == -1)
        {
            Console.WriteLine("Substring not found.");
            return original;
        }

        
        original = original.Remove(index, toRemove.Length);

        
        original = original.Insert(index, toInsert);

        return original;
    }

    static void Main()
    {
        string original = "HelloWorld";
        string removeStr = "World";
        string insertStr = "Universe";

        string result = ReplaceSubstring(original, removeStr, insertStr);

        Console.WriteLine("Result: " + result);
    }
}
