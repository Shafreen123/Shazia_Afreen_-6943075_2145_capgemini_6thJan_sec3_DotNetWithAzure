using System.Text;

namespace ConvertStringToUpperOrLower
{
    internal class Program
    {
        public static string Lowercase(string input)
        {
            StringBuilder sb = new StringBuilder();


            foreach (var item in input)
            {
                char ch = item;

                if (item >= 'a' && item <= 'z')
                {
                    ch = (char)(item - 32);
                }
                sb.Append(ch);
            }

            return sb.ToString();
        }

        public static string Uppercase(string input)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in input)
            {
                char ch = item;

                if (item >= 'A' && item <= 'Z')
                {
                    ch = (char)(item + 32);
                }

                sb.Append(ch);
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();

            Console.WriteLine(Lowercase(str1));

            Console.WriteLine(Uppercase(str1));

        }
    }
}