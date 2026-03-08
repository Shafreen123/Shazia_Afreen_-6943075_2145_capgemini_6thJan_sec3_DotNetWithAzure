using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<string> FindUniqueWords(List<string> words)
    {
        Dictionary<string, int> map = new Dictionary<string, int>();

      
        foreach (string word in words)
        {
            string sorted = String.Concat(word.OrderBy(c => c));

            if (map.ContainsKey(sorted))
                map[sorted]++;
            else
                map[sorted] = 1;
        }

       
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            string sorted = String.Concat(word.OrderBy(c => c));

            if (map[sorted] == 1)
                result.Add(word);
        }

        return result;
    }

    static void Main()
    {
        List<string> words = new List<string>
        {
            "listen", "silent", "hello", "world", "abc", "cba"
        };

        List<string> uniqueWords = FindUniqueWords(words);

        Console.WriteLine("Unique Words:");
        foreach (var word in uniqueWords)
        {
            Console.WriteLine(word);
        }
    }
}
