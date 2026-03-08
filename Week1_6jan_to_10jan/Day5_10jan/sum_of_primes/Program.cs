namespace day_5_3
{
    internal class Program
    {
        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= n / 2; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        static void Main()
        {
            int[] input1 = { 1, 2, 3, 4, 5 };
            int input2 = 5;
            int output = 0;
            bool primeFound = false;

            if (input2 < 0)
            {
                output = -2;
            }
            else
            {
                for (int i = 0; i < input2; i++)
                {
                    if (input1[i] < 0)
                    {
                        output = -1;
                        Console.WriteLine(output);
                        return;
                    }

                    if (IsPrime(input1[i]))
                    {
                        output += input1[i];
                        primeFound = true;
                    }
                }

                if (!primeFound)
                    output = -3;
            }

            Console.WriteLine(output);

        }
    }
}
