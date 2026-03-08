namespace CheckPalindromeInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            str1 = str1.ToLower();

            bool flag = true;

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == str1[str1.Length - 1 - i])
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }

            }

            if (flag)
            {
                Console.WriteLine("Palindrome!");
            }
            else
            {
                Console.WriteLine("Not A Palindrome");
            }

        }
    }
}