using System;

class SavingsCalculator
{
    static int CalculateSavings(int salary, int days)
    {
        
        if (salary > 9000)
            return -1;

        if (salary < 0)
            return -2;

        if (days < 0)
            return -4;

       
        int expenses = (int)(salary * 0.70);

      
        int bonus = (days == 31) ? 500 : 0;

       
        int savings = salary + bonus - expenses;

        return savings;
    }

    static void Main()
    {
        Console.WriteLine("Enter Salary");
        int input1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of days");
        int input2 = int.Parse(Console.ReadLine());   

        int result = CalculateSavings(input1, input2);
        Console.WriteLine("Output: " + result);
    }
}
