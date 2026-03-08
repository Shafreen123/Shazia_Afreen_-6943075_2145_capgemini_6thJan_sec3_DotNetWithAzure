using System;

class Program
{
    static bool AreAnagrams(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        int[] freq = new int[26];

        foreach (char c in s1)
            freq[c - 'a']++;

        foreach (char c in s2)
            freq[c - 'a']--;

        foreach (int count in freq)
        {
            if (count != 0)
                return false;
        }

        return true;
    }

    static void Main()
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();

        if (AreAnagrams(s1, s2))
            Console.WriteLine("YES");
        else
            Console.WriteLine("NO");
    }
}
