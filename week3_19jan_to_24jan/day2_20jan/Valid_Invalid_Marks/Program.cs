namespace Valid_Invalid_Marks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter marks of x");
            int X = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter marks of y");
            int Y = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of question in x");
            int no_x=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of question in y");
            int no_y=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter marks obtain");
            int marks=int.Parse(Console.ReadLine());
            bool token=false;
            int x_question=0, y_question=0;
            for(int i=1;i<=no_x;i++)
            {
                for(int j=1;j<=no_y;j++)
                {
                    if ((i * X) + (j * Y) == marks)
                    {
                        token = true;
                        x_question = i; y_question=j;
                        goto END;
                    }
                }
            }
        END:
            if (token == true)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(x_question);
                Console.WriteLine(y_question);
            }
            else
            {
                Console.WriteLine("Invalid");
            }


        }
    }
}
