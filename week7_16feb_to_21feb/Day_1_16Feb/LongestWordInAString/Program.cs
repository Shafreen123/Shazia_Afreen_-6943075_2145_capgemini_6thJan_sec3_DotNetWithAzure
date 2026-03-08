namespace LongestWordInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello Worlds I am flabbergasted today";
            string[] str2 = str1.Split(' ');
            string str3 = "";

            int maxlen = 0;

            foreach (var item in str2)
            {
                if (item.Length > maxlen)
                {
                    maxlen = item.Length;
                    str3 = item;
                }
            }

            Console.WriteLine(str3 + " - " + maxlen);
        }
    }
}