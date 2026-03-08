using System;

class Program
{
    static int CountVowels(string s)
    {
        int count = 0;
        s = s.ToLower();

        foreach (char c in s)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(CountVowels(s));
    }
}
