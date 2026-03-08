using System;
using System.Collections.Generic;

class Program
{
    static char FirstNonRepeatingCharacter(string s)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

       
        foreach (char c in s)
        {
            if (freq[c] == 1)
                return c;
        }

        return '\0'; 
    }

    static void Main()
    {
        string s = Console.ReadLine();
        char result = FirstNonRepeatingCharacter(s);

        if (result == '\0')
            Console.WriteLine("-1");
        else
            Console.WriteLine(result);
    }
}
