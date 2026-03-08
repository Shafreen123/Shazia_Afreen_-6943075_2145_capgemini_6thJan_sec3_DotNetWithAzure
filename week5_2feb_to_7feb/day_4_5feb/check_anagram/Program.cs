using System;
using System.Linq;

class Program
{
    static bool AreAllAnagrams(string[] words)
    {
        string baseWord = String.Concat(words[0].OrderBy(c => c));

        foreach (string word in words)
        {
            if (String.Concat(word.OrderBy(c => c)) != baseWord)
                return false;
        }

        return true;
    }

    static void Main()
    {
        string input = Console.ReadLine(); // dusty,study,dust,stydy
        string[] words = input.Split(',');

        Console.WriteLine(AreAllAnagrams(words));
    }
}
