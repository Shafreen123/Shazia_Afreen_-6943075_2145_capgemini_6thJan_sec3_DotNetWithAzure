namespace CountConsonantsAndVowels
{
    internal class Program
    {
        public static bool IsVowel(char c)
        {
            if ("AEIOUaeiou".Contains(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();

            int countVow = 0;
            int countCon = 0;

            foreach (var item in str1)
            {
                if (IsVowel(item))
                {
                    countVow++;
                }
                else
                {
                    countCon++;
                }
            }

            Console.WriteLine("No of Vowels: " + countVow);
            Console.WriteLine("No of Consosnants: " + countCon);


        }
    }
}