namespace FindNextElementThatIsGreaterAndDivisible
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = [1, 2, 3, 4, 5, 6];

            int count = 0;

            Array.Sort(input1);

            for (int i = 0; i < input1.Length; i++)
            {

                for (int j = i + 1; j < input1.Length; j++)
                {
                    if (input1[j] % input1[i] == 0)
                    {
                        count++;
                        break;
                    }
                }

            }

            Console.WriteLine(count);
        }
    }
}