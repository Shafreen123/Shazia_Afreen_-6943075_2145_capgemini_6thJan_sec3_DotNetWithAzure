namespace day_5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 12, 34, 56, 17, 2 };
            int input2 = 5;

            if (input2 < 0)
            {
                input1[0] = -2;
            }
            else if (input2 % 2 == 0)
            {
                input1[0] = -3;
            }
            else
            {
                for (int i = 0; i < input2; i++)
                {
                    if (input1[i] < 0)
                    {
                        input1[0] = -1;
                        break;
                    }
                }

                int mid = input2 / 2;
                for (int i = 0; i < mid; i++)
                {
                    int temp = input1[i];
                    input1[i] = input1[input2 - 1 - i];
                    input1[input2 - 1 - i] = temp;
                }
            }

            foreach (int val in input1)
                Console.Write(val + " ");
        }
    }
}
