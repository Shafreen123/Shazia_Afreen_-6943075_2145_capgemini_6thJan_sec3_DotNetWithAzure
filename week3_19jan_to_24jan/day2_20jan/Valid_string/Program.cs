using System;

namespace LuckyString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();

            if (n > str.Length)
            {
                Console.WriteLine("Invalid");
                return;
            }

            int required = n / 2;

            for (int i = 0; i <= str.Length - n; i++)
            {
                string window = str.Substring(i, n);

                
                bool validChars = true;
                foreach (char c in window)
                {
                    if (c != 'P' && c != 'S' && c != 'G')
                    {
                        validChars = false;
                        break;
                    }
                }

                if (!validChars)
                    continue;

                
                int count = 1;
                bool lucky = false;

                for (int j = 1; j < window.Length; j++)
                {
                    if (window[j] == window[j - 1])
                    {
                        count++;
                        if (count >= required)
                        {
                            lucky = true;
                            break;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }

                if (lucky)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
        }
    }
}
