namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int answer=1;
            Console.WriteLine("Give the value whose factorial you want");
            n = int.Parse(Console.ReadLine());
            if (n < 1)
            {
                answer = -1;
            }
            else if (n <= 7 && n >= 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    answer = answer * i;
                }
            }
            else
            {
                answer = -2;
            }
                Console.WriteLine("Foctorial is " + answer);
            Console.ReadLine();

        }
    }
}
