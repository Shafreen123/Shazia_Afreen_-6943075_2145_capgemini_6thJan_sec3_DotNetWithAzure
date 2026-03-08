using System;

class Program
{
    static void Main()
    {
        string s = "abcdef";
        string result = "";

        for (int i = 0; i < s.Length; i += 2) 
        {
            result += s[i];
        }

        Console.WriteLine("Original String: " + s);
        Console.WriteLine("After Deleting Alternating Characters: " + result);
    }
}

