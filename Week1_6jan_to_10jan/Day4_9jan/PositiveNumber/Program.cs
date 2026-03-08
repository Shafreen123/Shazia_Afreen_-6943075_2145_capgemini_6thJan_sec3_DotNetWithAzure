namespace PositiveNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int num = int.Parse(Console.ReadLine());
            int output;

            if (num < 0)
            {
                output = -1;
            }
            else if (num > 32767)
            {
                output = -2;
            }
            else
            {
                int sum = 0;
                while (num > 0)
                {
                    int digit = num % 10;
                    if (digit % 2 == 0)
                    {
                        sum += digit;
                    }
                    num /= 10;
                }
                output = sum;
            }

            Console.WriteLine(output);
        }
    }
}
