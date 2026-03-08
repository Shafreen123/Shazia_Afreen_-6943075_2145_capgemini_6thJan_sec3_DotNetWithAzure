namespace Divisible_5_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value ");
            int n = int.Parse(Console.ReadLine());
            int output = 0;
            if (n < 0)
            {
                output = -1;
                Console.WriteLine(output);
                return;
            }
            for (int i = 0; i <= n; i++)
            {
                if (i % 5 == 0)
                {
                    output = output + i;
                }
            }
            Console.WriteLine(output);
        }
    }
}
