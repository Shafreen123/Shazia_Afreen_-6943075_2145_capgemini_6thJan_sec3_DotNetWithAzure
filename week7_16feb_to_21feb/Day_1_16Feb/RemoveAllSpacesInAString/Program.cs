using System.Text;

namespace RemoveAllSpacesInAString
{
    internal class Program
    {
        public static bool IsVowel(char ch)
        {
            if (" ".Contains(ch))
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string str1 = "Hello World My Name is Parth";
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