namespace NotDivisibleByOtherElementsInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = [24, 11, 8, 3, 16];

            int count = 0;


            for (int i = 0; i < input1.Length; i++)
            {
                bool flag = false;

                for (int j = 0; j < input1.Length; j++)
                {
                    if (input1[i] == input1[j])
                    {
                        continue;
                    }

                    if (input1[i] % input1[j] == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}