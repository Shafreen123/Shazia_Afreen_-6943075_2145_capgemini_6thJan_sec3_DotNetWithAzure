using System;

class Program
{
    static void Main()
    {
        int limit = Convert.ToInt32(Console.ReadLine());

        if (limit < 0)
        {
            Console.WriteLine("-1");
            return;
        }

        if (limit > 32767)
        {
            Console.WriteLine("-2");
            return;
        }

        long sum = 0;

        for (int i = 2; i <= limit; i++)
        {
            bool prime = true;

            for (int j = 2; j * j <= i; j++)
            {
                if (i % j == 0)
                {
                    prime = false;
                    break;
                }
            }

            if (prime)
                sum += (long)i * i * i;
        }

        Console.WriteLine(sum);
    }
}
