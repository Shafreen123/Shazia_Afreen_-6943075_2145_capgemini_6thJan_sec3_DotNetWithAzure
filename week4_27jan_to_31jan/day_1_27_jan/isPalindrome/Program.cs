using System;

class Program
{
    static bool IsPalindrome(string s)
    {
        s = s.ToLower();
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

    static void Main()
    {
        string s = Console.ReadLine();

        if (IsPalindrome(s))
            Console.WriteLine("YES");
        else
            Console.WriteLine("NO");
    }
}
