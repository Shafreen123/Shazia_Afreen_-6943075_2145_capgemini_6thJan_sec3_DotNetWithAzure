using System;

class Program
{
    static int CheckSubstrings(string input1, string input2, string input3)
    {
        int index2 = input1.IndexOf(input2);
        int index3 = input1.IndexOf(input3);

        if (index2 != -1 && index3 != -1 && index3 > index2)
        {
            return 1;
        }

        return -1;
    }

    static void Main()
    {
        string input1 = "todayisc#exam";
        string input2 = "is";
        string input3 = "exam";

        int result = CheckSubstrings(input1, input2, input3);
        Console.WriteLine("Output: " + result);
    }
}
