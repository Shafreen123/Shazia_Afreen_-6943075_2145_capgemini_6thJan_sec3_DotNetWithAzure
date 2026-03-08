namespace RemoveConsecutiveVowels
{
    internal class Program
    {
        public static bool IsVowel(char ch)
        {
            if ("AEIOUaeiou".Contains(ch)) return true;

            return false;
        }
        static void Main(string[] args)
        {
            String str1 = Console.ReadLine();
            int count = 0;

            for (int i = 0; i < str1.Length - 1; i++)
            {
                if (IsVowel(str1[i + 1]) && IsVowel(str1[i]))
                {
                    count++;
                    i++;
                }
            }

            Console.WriteLine(count);
        }
    }
}