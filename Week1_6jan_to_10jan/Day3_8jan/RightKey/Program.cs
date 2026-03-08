namespace RightKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a key: ");
            char key = Convert.ToChar(Console.ReadLine()); 
            int ascii = (int)key; 
            if (ascii >= 48 && ascii <= 57) 
                Console.WriteLine("Number pressed: " + key);
            else
                Console.WriteLine("Not allowed");
            Console.ReadLine();
        }
    }
}
