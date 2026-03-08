using System;

class Program
{
    static void FindPass(int n, int t)
    {
        int current = 1;
        int direction = 1; // 1 = forward, -1 = backward
        int from = 0, to = 0;

        for (int i = 1; i <= t; i++)
        {
            from = current;
            current += direction;
            to = current;

            if (current == n)
                direction = -1;
            else if (current == 1)
                direction = 1;
        }

        Console.WriteLine($"At {t} second: {from} passed to {to}");
    }

    static void Main()
    {
        int N = 4;
        int T = 10;

        FindPass(N, T);
    }
}
