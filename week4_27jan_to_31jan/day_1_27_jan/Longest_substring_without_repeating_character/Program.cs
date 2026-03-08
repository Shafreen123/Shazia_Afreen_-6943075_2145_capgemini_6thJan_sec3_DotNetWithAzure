using System;
using System.Collections.Generic;

class Program
{
    static int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> charIndex = new Dictionary<char, int>();
        int maxLength = 0;
        int start = 0;

        for (int end = 0; end < s.Length; end++)
        {
            char currentChar = s[end];

            if (charIndex.ContainsKey(currentChar) && charIndex[currentChar] >= start)
            {

                start = charIndex[currentChar] + 1;
            }


            charIndex[currentChar] = end;


            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }

    static void Main()
    {
        string s = Console.ReadLine();
        int result = LengthOfLongestSubstring(s);
        Console.WriteLine(result);
    }
}
