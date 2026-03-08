namespace GreatestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Enter first number: ");
            a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            b = int.Parse(Console.ReadLine());

            Console.Write("Enter third number: ");
            c = int.Parse(Console.ReadLine());

            int greatest = a;

            if (b > greatest)
                greatest = b;
            if (c > greatest)
                greatest = c;

            Console.WriteLine("Greatest value is: " + greatest);
        }
    }
}
