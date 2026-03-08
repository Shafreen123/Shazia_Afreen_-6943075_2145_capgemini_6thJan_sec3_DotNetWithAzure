using System;

class Program
{
    static bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    static int CalculateScore(string str)
    {
        int score = 0;
        int n = str.Length;

       
        for (int i = 0; i <= n - 4; i++)
        {
            string sub = str.Substring(i, 4);
            if (IsPalindrome(sub))
                score += 5;
        }

       
        for (int i = 0; i <= n - 5; i++)
        {
            string sub = str.Substring(i, 5);
            if (IsPalindrome(sub))
                score += 10;
        }

        return score;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        int result = CalculateScore(input);

        Console.WriteLine("Final Score: " + result);
    }
}
