using System;

public class UserProgramCode
{
    public static int GetCount(int input1, string[] input2, char input3)
    {
        int count = 0;
        char ch = char.ToLower(input3);

        foreach (string s in input2)
        {
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                    return -2;   // Only alphabets allowed
            }

            if (char.ToLower(s[0]) == ch)
                count++;
        }

        if (count == 0)
            return -1;

        return count;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] arr = new string[n];

        for (int i = 0; i < n; i++)
            arr[i] = Console.ReadLine();

        char ch = Console.ReadLine()[0];

        int result = UserProgramCode.GetCount(n, arr, ch);

        if (result == -1)
            Console.WriteLine("No elements Found");
        else if (result == -2)
            Console.WriteLine("Only alphabets should be given");
        else
            Console.WriteLine(result);
    }
}
