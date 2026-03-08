using System.Text;

namespace RemoveDuplicateFromString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Invigilation";

            str1 = str1.ToLower();

            StringBuilder str2 = new StringBuilder();

            HashSet<char> hs = new HashSet<char>();

            foreach (var item in str1)
            {
                hs.Add(item);
            }

            foreach (var item in hs)
            {
                str2.Append(item);
            }

            Console.WriteLine(str2);
        }
    }
}