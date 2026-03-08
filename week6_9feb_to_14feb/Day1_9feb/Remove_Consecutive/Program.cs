using System;

public class Solution
{
    public static int MaxDeletions(string s)
    {
        int count = 0;
        int i = 0;

        while (i < s.Length - 1)
        {
            
            if (s[i] != '\0')   
            {
                count++;        
                i += 2;         
            }
            else
            {
                i++;
            }
        }

        return count;
    }

    public static void Main()
    {
        string s = "aabbcc";
        Console.WriteLine(MaxDeletions(s));  // Output: 3
    }
}
