namespace StringLengthWithoutFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Hello, I am Parth";

            int count = 0;

            foreach (var item in str1)
            {
                count++;
            }

            Console.WriteLine(count);
        }
    }
}