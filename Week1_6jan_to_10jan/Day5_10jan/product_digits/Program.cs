namespace day_5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1 = 56;
            int output = 1;
            int product = 1;

            if (input1 < 0)
            {
                output = -1;
            }
            else if (input1 % 3 == 0 || input1 % 5 == 0)
            {
                output = -2;
            }
            else
            {
                while (input1 > 0)
                {
                    int digit = input1 % 10;
                    product *= digit;
                    input1 /= 10;
                }

                if (product % 3 == 0 || product % 5 == 0)
                    output = 1;
                else
                    output = 0;
            }

            Console.WriteLine(output);

        }
    }
}
