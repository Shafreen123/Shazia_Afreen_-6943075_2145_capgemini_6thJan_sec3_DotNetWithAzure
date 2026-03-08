using System;

class Program
{
    static int LongestPalindromeLength(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int maxLength = 1;

        for (int i = 0; i < s.Length; i++)
        {
            
            maxLength = Math.Max(maxLength, ExpandFromCenter(s, i, i));

           
            maxLength = Math.Max(maxLength, ExpandFromCenter(s, i, i + 1));
        }

        return maxLength;
    }

    static int ExpandFromCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        return right - left - 1; 
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        int result = LongestPalindromeLength(input);

        Console.WriteLine("Length of longest palindromic substring: " + result);
    }
}
