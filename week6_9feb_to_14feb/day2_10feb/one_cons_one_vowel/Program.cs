using System;

class Program
{
    static int CountValidWords(string input)
    {
        string[] words = input.Split(' ');
        int validCount = 0;

        foreach (string word in words)
        {
            if (word.Length <= 2)
                continue;

            bool hasVowel = false;
            bool hasConsonant = false;
            bool isValid = true;

            foreach (char ch in word)
            {
                // Check if character is letter or digit
                if (!char.IsLetterOrDigit(ch))
                {
                    isValid = false;
                    break;
                }

                if (char.IsLetter(ch))
                {
                    char lower = char.ToLower(ch);

                    if ("aeiou".Contains(lower))
                        hasVowel = true;
                    else
                        hasConsonant = true;
                }
            }

            if (isValid && hasVowel && hasConsonant)
                validCount++;
        }

        return validCount;
    }

    static void Main()
    {
        string input = "Hello abc 123 world a1b !test go";
        Console.WriteLine(CountValidWords(input));
    }
}
