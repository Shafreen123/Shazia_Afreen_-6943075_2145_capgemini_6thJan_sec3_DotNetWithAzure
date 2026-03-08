namespace perfect_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 6;
            int sum = 0;

            if (num < 0)
            {
                Console.WriteLine(-2);
                return;
            }

            for (int i = 1; i < num; i++)
                if (num % i == 0)
                    sum += i;

            if (sum == num)
                Console.WriteLine(1);
            else
                Console.WriteLine(-1);
        }
    }
}
