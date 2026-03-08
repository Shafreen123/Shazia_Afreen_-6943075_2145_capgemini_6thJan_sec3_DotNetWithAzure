using System;

class Program
{
    static int MaxDeletions(string s)
    {
        int count = 0;
        int i = 0;

        while (i < s.Length - 1)
        {
            if (s[i] == s[i + 1])
            {
                count++;
                i += 2;   // skip the pair
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
        string s = Console.ReadLine();
        Console.WriteLine(MaxDeletions(s));
    }
}
