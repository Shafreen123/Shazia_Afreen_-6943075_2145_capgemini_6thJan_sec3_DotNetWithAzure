namespace multiple_of_three
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 6, 7, 9 };
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                if (arr[i] % 3 == 0)
                    count++;
            }

            Console.WriteLine(count);
        }
    }
}
