namespace Binary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter binary number");
            int input1 = int.Parse(Console.ReadLine());
            int output = 0;
            int power = 1; 

            
            if (input1 > 11111)
            {
                Console.WriteLine("-2");
                return;
            }

            int temp = input1;

            while (temp > 0)
            {
                int digit = temp % 10;

               
                if (digit != 0 && digit != 1)
                {
                    Console.WriteLine("-1");
                    return;
                }

                output = output + (digit * power);
                power = power * 2;
                temp = temp / 10;
            }

            Console.WriteLine(output);
        
    }
    }
}
