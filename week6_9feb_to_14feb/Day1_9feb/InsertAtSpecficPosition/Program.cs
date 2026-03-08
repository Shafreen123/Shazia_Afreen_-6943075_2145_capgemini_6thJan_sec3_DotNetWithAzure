using System;

class Program
{
    static void Main()
    {
        string original = "Hello World";
        char ch = 'A';
        int position = 3;   

      
        string result = original.Insert(position, ch.ToString());

        Console.WriteLine("Original String: " + original);
        Console.WriteLine("Updated String: " + result);
    }
}
