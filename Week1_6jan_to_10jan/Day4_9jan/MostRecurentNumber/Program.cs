namespace MostRecurentNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            int maxCount = 0;

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (arr[i] == arr[j])
                        count++;
                }
                if (count > maxCount)
                    maxCount = count;
            }

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                bool printed = false;

                for (int j = 0; j < n; j++)
                    if (arr[i] == arr[j])
                        count++;

                for (int k = 0; k < i; k++)
                    if (arr[k] == arr[i])
                        printed = true;

                if (count == maxCount && !printed)
                    Console.Write(arr[i] + " ");
            }
        }

    }
}
