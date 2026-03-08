using System;

class Program
{
    static void Main()
    {
        int[] arr = { 5, 2, 8, 1, 6 };
        int size = arr.Length;
        int elementToInsert = 4;
        int output = 0;

       
        if (size < 0)
        {
            output = -2;
            Console.WriteLine(output);
            return;
        }

       
        foreach (int num in arr)
        {
            if (num < 0)
            {
                output = -1;
                Console.WriteLine(output);
                return;
            }
        }

        
        Array.Sort(arr);

        int[] newArr = new int[size + 1];
        int i = 0, j = 0;
        bool inserted = false;

        while (i < size)
        {
            if (!inserted && elementToInsert < arr[i])
            {
                newArr[j++] = elementToInsert;
                inserted = true;
            }
            newArr[j++] = arr[i++];
        }

        if (!inserted)
        {
            newArr[j] = elementToInsert;
        }

     
        foreach (int num in newArr)
        {
            Console.Write(num + " ");
        }
    }
}
