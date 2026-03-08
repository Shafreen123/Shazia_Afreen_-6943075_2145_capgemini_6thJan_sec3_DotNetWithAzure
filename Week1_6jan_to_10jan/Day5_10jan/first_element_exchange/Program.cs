namespace day_5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 21, 23, 41, 4 };
            int[] input2 = { 3, 4, 1, 5 };
            int input3 = 4;
            int[] output = new int[input3];

            if (input3 < 0)
            {
                output[0] = -2;
            }
            else
            {
                for (int i = 0; i < input3; i++)
                {
                    if (input1[i] < 0 || input2[i] < 0)
                    {
                        output[0] = -1;
                        break;
                    }
                    output[i] = input1[i] + input2[i];
                }
            }

            foreach (int val in output)
                Console.Write(val + " ");
        }
    }
}
