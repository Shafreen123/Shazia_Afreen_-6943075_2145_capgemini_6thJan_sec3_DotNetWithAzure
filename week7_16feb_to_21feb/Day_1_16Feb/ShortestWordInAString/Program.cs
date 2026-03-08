namespace ShortestWordInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello Worlds I am flabbergasted today";
            string[] str2 = str1.Split(' ');
            string str3 = "";

            int minlen = int.MaxValue;

            foreach (var item in str2)
            {
                if (item.Length < minlen)
                {
                    minlen = item.Length;
                    str3 = item;
                }
            }

            Console.WriteLine(str3 + " - " + minlen);
        }
    }
}
