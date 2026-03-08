using System.Text;

namespace RemoveAllVowelsFromAString
{
    internal class Program
    {
        public static bool IsVowel(char ch)
        {
            if ("AEIOUaeiou".Contains(ch))
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string str1 = "Hello World";
            StringBuilder sb = new StringBuilder();

            foreach (var item in str1)
            {
                if (!IsVowel(item))
                {
                    sb.Append(item);
                }
            }

            Console.WriteLine(sb.ToString());

        }
    }
}