using System.Text;

namespace ToggleCaseOfEachCharacter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello123";
            StringBuilder sb = new StringBuilder();

            char[] ch = str1.ToCharArray();

            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] >= 'A' && ch[i] <= 'Z')
                {
                    ch[i] = (char)(ch[i] + 32);
                }
                else if (ch[i] >= 'a' && ch[i] <= 'z')
                {
                    ch[i] = (char)(ch[i] - 32);
                }


                sb.Append(ch[i]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}