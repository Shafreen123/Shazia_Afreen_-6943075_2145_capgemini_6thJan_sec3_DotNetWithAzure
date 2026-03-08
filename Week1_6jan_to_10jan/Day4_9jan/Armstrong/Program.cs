using System;

namespace Armstrong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter  number");
            n = int.Parse(Console.ReadLine());
            int length = n.ToString().Length;
            int answer = 1;
            if (n < 0)
            {
                answer = -1;
            }
            else if (length > 3)
            {
                answer = -2;
            }
            else
            {
                int sum = 0;
                int temp = n;
                int digits = n.ToString().Length;

                while (temp > 0)
                {
                    int rem = temp % 10;
                    sum += (int)Math.Pow(rem, digits);
                    temp /= 10;
                }

                if (sum == n)
                    answer = 1;
                else
                    answer = 0;
            }
            Console.WriteLine(answer);
            Console.ReadLine();
            }
        }
    }

