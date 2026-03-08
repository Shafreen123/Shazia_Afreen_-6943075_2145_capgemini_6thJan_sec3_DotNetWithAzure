using System;

public class UserProgramCode
{
    public static int sumOfDigits(string[] input1)
    {
        int sum = 0;

        foreach (string s in input1)
        {
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                    continue;
                else if (char.IsDigit(c))
                    sum += c - '0';
                else
                    return -1; 
            }
        }
        return sum;
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

        int result = UserProgramCode.sumOfDigits(arr);
        Console.WriteLine(result);
    }
}
