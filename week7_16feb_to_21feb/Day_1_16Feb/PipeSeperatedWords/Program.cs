namespace PipeSeperatedWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "A,|D|B|C|E!";

            string[] str2 = str1.Split('|');

            Array.Sort(str2);

            string str3 = "";

            foreach (var item in str2)
            {
                str3 += item + "|";
            }

            str3 = str3.Trim('|');

            Console.WriteLine(str3);
        }
    }
}