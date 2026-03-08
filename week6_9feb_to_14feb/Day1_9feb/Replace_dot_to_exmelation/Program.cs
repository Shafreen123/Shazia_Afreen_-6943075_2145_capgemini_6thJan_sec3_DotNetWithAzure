using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        Console.Write("Enter character to replace: ");
        char oldChar = Convert.ToChar(Console.ReadLine());

        Console.Write("Enter character to replace with: ");
        char newChar = Convert.ToChar(Console.ReadLine());

        int index = input.IndexOf(oldChar);

        if (index != -1)
        {
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            input = new string(chars);
        }

        Console.WriteLine("\nString after replacement: " + input);
    }
}
