using System.Text;

namespace ConcatenateStringWithoutFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello,";
            string str2 = "World!";

            string str = "";

            foreach (var item in str1)
            {
                str += item;
            }

            str += " ";

            foreach (var item in str2)
            {
                str += item;
            }

            Console.WriteLine(str);

        }
    }
}