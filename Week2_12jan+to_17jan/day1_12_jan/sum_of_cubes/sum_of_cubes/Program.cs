using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine(-1);
            return;
        }

        if (n > 32676)
        {
            Console.WriteLine(-2);
            return;
        }

        int sum = 0;

        for (int i = 2; i <= n; i++)
        {
            bool prime = true;
            for (int j = 2; j <= i / 2; j++)
                if (i % j == 0)
                    prime = false;

            if (prime)
                sum += i * i * i;
        }

        Console.WriteLine(sum);
    }
}
