namespace LocatioNElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int output;

            if (n < 0)
            {
                output = -2;
                Console.WriteLine(output);
                return;
            }

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] < 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            int key = int.Parse(Console.ReadLine());
            output = 1;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == key)
                {
                    output = i;
                    break;
                }
            }

            Console.WriteLine(output);
        }
    }
}
