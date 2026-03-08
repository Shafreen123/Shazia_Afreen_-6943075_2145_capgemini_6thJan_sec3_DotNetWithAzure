using System;

namespace Constructor_Variable
{
    internal class Demo
    {
        const int k = 5;

        static int a;
        static readonly int b;

        int c;
        readonly int d;

        static Demo()
        {
            a = 10;
            b = 20;
            Console.WriteLine("Static Constructor: a = " + a + ", b = " + b + ", k = " + k);
        }

        public Demo()
        {
            c = 30;
            d = 40;
            Console.WriteLine("Instance Constructor: c = " + c + ", d = " + d + ", k = " + k);
        }

        public void Display()
        {
            Console.WriteLine("Display: a = " + a + ", b = " + b + ", c = " + c + ", d = " + d + ", k = " + k);
        }
    }

    class Program
    {
        static void Main()
        {
            Demo obj1 = new Demo();
            obj1.Display();

            Console.WriteLine("------");

            Demo obj2 = new Demo();
            obj2.Display();
        }
    }
}
