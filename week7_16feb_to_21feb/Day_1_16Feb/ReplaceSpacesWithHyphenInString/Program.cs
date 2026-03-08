using System.Text;

namespace ReplaceSpacesWithHyphenInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello World I am a Student";
            StringBuilder sb1 = new StringBuilder();

            foreach (var item in str1)
            {
                char ch = item;

                if (" ".Contains(item))
                {
                    ch = '-';
                }

                sb1.Append(ch);
            }

            Console.WriteLine(sb1.ToString());

        }
    }
}