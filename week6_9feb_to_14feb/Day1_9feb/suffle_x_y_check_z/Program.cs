using System;

class Program
{
    static bool IsPerfectShuffle(string x, string y, string z)
    {
        if (z.Length != x.Length + y.Length)
            return false;

        int i = 0, j = 0, k = 0;

        while (k < z.Length)
        {
            if (i < x.Length && z[k] == x[i])
            {
                i++;
            }
            else if (j < y.Length && z[k] == y[j])
            {
                j++;
            }
            else
            {
                return false;
            }

            k++;
        }

        return (i == x.Length && j == y.Length);
    }

    static void Main()
    {
        Console.Write("Enter string x: ");
        string x = Console.ReadLine();

        Console.Write("Enter string y: ");
        string y = Console.ReadLine();

        Console.Write("Enter string z: ");
        string z = Console.ReadLine();

        bool result = IsPerfectShuffle(x, y, z);

        Console.WriteLine(result ? "Perfect Shuffle" : "Not a Perfect Shuffle");
    }
}
