namespace No_of_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("enter the number");
            n=int.Parse(Console.ReadLine());
            int temp = n;
            int count = 0;
            if(n<0)
            {
                count = -1;
            }
            else
            {
                while(temp>0)
                {
                    temp = temp / 10;
                    count++;
                }
            }
            Console.WriteLine("No_of_numbers of digit are "+count);
            Console.ReadLine();
        }
    }
}
