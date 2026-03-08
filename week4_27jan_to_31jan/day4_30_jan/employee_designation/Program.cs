using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class UserProgramCode
{
    public static string[] getEmployee(string[] input1, string input2)
    {
        Regex reg = new Regex("^[a-zA-Z ]+$");
        if (!reg.IsMatch(input2)) return new string[] { "Invalid Input" };

        foreach (string s in input1)
            if (!reg.IsMatch(s)) return new string[] { "Invalid Input" };

        List<string> result = new List<string>();
        bool allSame = true;
        string firstDesig = input1[1];

        for (int i = 0; i < input1.Length; i += 2)
        {
            if (!input1[i + 1].Equals(firstDesig, StringComparison.OrdinalIgnoreCase))
                allSame = false;

            if (input1[i + 1].Equals(input2, StringComparison.OrdinalIgnoreCase))
                result.Add(input1[i]);
        }

        if (allSame)
            return new string[] { "All employees belong to same " + input2 + " designation" };

        if (result.Count == 0)
            return new string[] { "No employee for " + input2 + " designation" };

        return result.ToArray();
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

        string designation = Console.ReadLine();

        string[] output = UserProgramCode.getEmployee(arr, designation);
        Console.WriteLine(string.Join(" ", output));
    }
}
