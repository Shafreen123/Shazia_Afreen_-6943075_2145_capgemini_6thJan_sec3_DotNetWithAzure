namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter the size of arrays");
            n = int.Parse(Console.ReadLine());
            int result = 1;
            if(n<0)
            {
                result = -2;
                return;
            }
            int[] arr1 = new int[n];
            Console.WriteLine("Enter the values of array");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element at index " + i + ": ");
                arr1[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0;i < n; i++)
            {
                if (arr1[i]>0)
                {
                    result = result * arr1[i];
                }
            }

            Console.WriteLine(" the multiplication of positive number "+result);
            Console.ReadLine();
        }
    }
}
