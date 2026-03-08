using System;

class Program
{
    static int LongestNonDecreasingSubstring(string s)
    {
        int n = s.Length;
        int badBlocks = 0;

        for (int i = 0; i < n - 1; i += 2)
        {
            if (s[i] == '1' && s[i + 1] == '0')
                badBlocks++;
        }

        return n - badBlocks;
    }

    static void Main()
    {
        Console.Write("Enter binary string: ");
        string s = Console.ReadLine();

        int result = LongestNonDecreasingSubstring(s);

        Console.WriteLine("Longest non-decreasing substring length: " + result);
    }
}
