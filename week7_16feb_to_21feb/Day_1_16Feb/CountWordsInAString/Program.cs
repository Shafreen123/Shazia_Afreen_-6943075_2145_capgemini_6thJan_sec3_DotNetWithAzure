namespace CountWordsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello I am Parth";

            string[] str2 = str1.Split(' ');

            Console.WriteLine(str2.Length);
        }
    }
}