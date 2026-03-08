namespace FindAllSubstrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "abcde";

            for (int i = 0; i < str1.Length; i++)
            {
                string current = "";

                for (int j = i; j < str1.Length; j++)
                {
                    current += str1[j];
                    Console.WriteLine(current);
                }

            }

        }
    }
}