using System;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string s = Console.ReadLine();

            char[] arr = s.ToCharArray(); 
            int n = arr.Length;
            int q = n - 1;

            for (int i = 0; i < n / 2; i++)
            {
                char temp = arr[i];
                arr[i] = arr[q];
                arr[q] = temp;
                q--;
            }

            string reversed = new string(arr);
            Console.WriteLine("Reversed string: " + reversed);
        }
    }
}
