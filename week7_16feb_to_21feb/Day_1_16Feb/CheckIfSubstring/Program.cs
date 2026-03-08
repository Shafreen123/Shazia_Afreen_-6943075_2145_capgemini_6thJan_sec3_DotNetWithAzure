namespace CheckIfSubstring
{
    internal class Program
    {
        public static bool IsSubstring(string str1, string str2)
        {
            for (int i = 0; i <= (str1.Length - str2.Length); i++)
            {
                int j;
                for (j = 0; j < str2.Length; j++)
                {
                    if (str1[i + j] != str2[j])
                    {
                        break;
                    }
                }

                if (j == str2.Length)
                {
                    return true;
                }
            }

            return false;
        }


        static void Main(string[] args)
        {
            string str1 = "Hello";
            string str2 = "ell";

            Console.WriteLine(IsSubstring(str1, str2));

        }
    }
}