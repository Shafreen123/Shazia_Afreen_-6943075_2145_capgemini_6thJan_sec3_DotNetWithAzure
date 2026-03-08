using System;

class Program
{
    static string RemoveLastOccurrence(string input, string word)
    {
        int lastIndex = input.LastIndexOf(word);

        if (lastIndex == -1)
            return input;

        
        bool isStartValid = (lastIndex == 0 || input[lastIndex - 1] == ' ');
        bool isEndValid = (lastIndex + word.Length == input.Length ||
                          input[lastIndex + word.Length] == ' ' ||
                          input[lastIndex + word.Length] == '.');

        if (isStartValid && isEndValid)
        {
            return input.Remove(lastIndex, word.Length).Replace("  ", " ");
        }

        return input;
    }

    static void Main()
    {
        string input = "I am a programmer. I learn at Codeforwin.";
        string word = "I";

        string result = RemoveLastOccurrence(input, word);

        Console.WriteLine("Output:");
        Console.WriteLine(result);
    }
}
