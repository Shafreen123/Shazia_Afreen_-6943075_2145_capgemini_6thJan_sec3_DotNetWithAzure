using System.Text;

namespace ReverseWithoutFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello";

            StringBuilder sb = new StringBuilder();

            Stack<char> st = new Stack<char>();

            foreach (var item in str1)
            {
                st.Push(item);
            }

            foreach (var item in st)
            {
                sb.Append(item);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}