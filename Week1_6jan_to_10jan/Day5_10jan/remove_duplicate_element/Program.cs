namespace day_5_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 1, 2, 2, 3, 3 };
            int input2 = 5;

            if (input2 < 0)
            {
                Console.WriteLine("-2");
                return;
            }

            for (int i = 0; i < input2; i++)
            {
                if (input1[i] < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            for (int i = 0; i < input2; i++)
            {
                bool duplicate = false;
                for (int j = 0; j < i; j++)
                {
                    if (input1[i] == input1[j])
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate)
                    Console.Write(input1[i] + " ");

            }
        }
    }
}

