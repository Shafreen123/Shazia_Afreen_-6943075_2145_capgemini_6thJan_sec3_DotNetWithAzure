namespace sum_cube_prime
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
            int n = 7;
            int sum = 0;

            if (n < 0 || n > 7)
            {
                Console.WriteLine(-1);
                return;
            }

            for (int i = 2; i <= n; i++)
                if (IsPrime(i))
                    sum += i * i * i;

            Console.WriteLine(sum);

        }
    }
}
