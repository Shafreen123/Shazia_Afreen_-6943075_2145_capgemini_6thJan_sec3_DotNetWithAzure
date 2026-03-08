namespace Average_odd_even
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int oddsum = 0, evensum = 0;
            float average;
            Console.WriteLine("enter the size of array");
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the value fo index " + i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("----Your Array is----");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
            for (int i = 0; i < n; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    evensum = evensum + arr[i];
                }
                else
                {
                    oddsum = oddsum + arr[i];
                }
            }

            average = (evensum + oddsum) / n;
            Console.WriteLine("Average is" +average);
        }
    }
}
