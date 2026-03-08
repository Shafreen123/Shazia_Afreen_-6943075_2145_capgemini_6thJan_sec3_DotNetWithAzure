using System;
using System.Text;

class Program
{
    static string CompressString(string s)
    {
        if (string.IsNullOrEmpty(s))
            return "";

        StringBuilder compressed = new StringBuilder();
        int count = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                compressed.Append(s[i - 1]);
                compressed.Append(count);
                count = 1;
            }
        }

       
        compressed.Append(s[s.Length - 1]);
        compressed.Append(count);

        return compressed.ToString();
    }

    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(CompressString(s));
    }
}
