namespace average_multiple_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int n= int.Parse(Console.ReadLine());
            if(n<0)
            {
                Console.WriteLine(-1);
            }
            if(n>500)
            {
                Console.WriteLine(-2);
            }
            int average;
            int sum = 0;
            int count = 0;
            for(int i = 1; i <= n; i++)
            {
                if(i%5==0)
                {
                    sum = sum + i;
                    count++;
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(count);
            average = sum/count;
            Console.WriteLine(average);
            Console.ReadLine();
        }
    }
}
