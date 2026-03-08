namespace Farenhit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit = 98;

            if (fahrenheit < 0)
                Console.WriteLine(-1);
            else
            {
                double celsius = (fahrenheit - 32) * 5 / 9;
                Console.WriteLine(celsius);
            }
        }
    }
}
