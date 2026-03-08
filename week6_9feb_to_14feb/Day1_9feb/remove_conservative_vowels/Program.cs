using System;

class Program
{
    static bool IsVowel(char c)
    {
        c = char.ToLower(c);
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    static int CountVowelDeletions(string s)
    {
        int count = 0;
        int i = 0;

        while (i < s.Length - 1)
        {
            if (IsVowel(s[i]) && IsVowel(s[i + 1]))
            {
                count++;
                i += 2; 
            }
            else
            {
                i++;
            }
        }

        return count;
    }

    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        int result = CountVowelDeletions(input);

        Console.WriteLine("Number of deletions: " + result);
    }
}
