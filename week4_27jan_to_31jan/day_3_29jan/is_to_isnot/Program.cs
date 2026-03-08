using System;
using System.Text.RegularExpressions;

namespace is_to_isnot
{
    public class UserProgramCode
    {
        public static string negativeString(string input)
        {
            return Regex.Replace(input, @"\bis\b", "is not");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = UserProgramCode.negativeString(input);
            Console.WriteLine(result);
        }
    }
}
