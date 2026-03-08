namespace remove_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of array");
            int input2 = int.Parse(Console.ReadLine()) ;
            int[] input1 = new int[input2];
            for(int i=0;i<input2;i++)
            {
                input1[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine("enter key value");
            int input3 = int.Parse(Console.ReadLine()) ;

           
            if (input2 < 0)
            {
                Console.WriteLine("-2");
                return;
            }

            
            for (int i = 0; i < input2; i++)
            {
                if (input1[i] < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            
            bool found = false;
            for (int i = 0; i < input2; i++)
            {
                if (input1[i] == input3)
                {
                    found = true;
                    break;
                }
            }

         
            if (!found)
            {
                Console.WriteLine("-3");
                return;
            }

            int[] output = new int[input2 - 1];
            int index = 0;

            
            for (int i = 0; i < input2; i++)
            {
                if (input1[i] != input3)
                {
                    output[index++] = input1[i];
                }
            }

           
            Array.Sort(output);

            Console.Write("{ ");
            foreach (int num in output)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("}");
        }
    }
}
