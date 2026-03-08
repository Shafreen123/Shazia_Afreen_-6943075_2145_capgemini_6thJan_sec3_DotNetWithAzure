namespace SortCharacterOfStringAlphabetically
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "adcfg";
            str1 = str1.ToLower();
            char[] ch = str1.ToCharArray();

            Array.Sort(ch);

            ch.ToString();
            Console.WriteLine(ch);
        }
    }
}