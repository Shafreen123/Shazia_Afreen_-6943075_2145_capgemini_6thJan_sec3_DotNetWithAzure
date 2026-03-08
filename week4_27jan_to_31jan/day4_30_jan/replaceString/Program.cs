using System;
using System.Text.RegularExpressions;

public class UserProgramCode
{
    public static string replaceString(string input1, int input2, char input3)
    {
        if (!Regex.IsMatch(input1, "^[a-zA-Z ]+$"))
            return "-1";

        if (input2 <= 0)
            return "-2";

        if (char.IsLetterOrDigit(input3))
            return "-3";

        string[] words = input1.Split(' ');

        if (input2 > words.Length)
            return input1.ToLower();

        words[input2 - 1] = new string(input3, words[input2 - 1].Length);
        return string.Join(" ", words).ToLower();
    }
}

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        char c = Console.ReadLine()[0];

        string res = UserProgramCode.replaceString(s, n, c);

        if (res == "-1") Console.WriteLine("Invalid String");
        else if (res == "-2") Console.WriteLine("Number not positive");
        else if (res == "-3") Console.WriteLine("Character not a special character");
        else Console.WriteLine(res);
    }
}
