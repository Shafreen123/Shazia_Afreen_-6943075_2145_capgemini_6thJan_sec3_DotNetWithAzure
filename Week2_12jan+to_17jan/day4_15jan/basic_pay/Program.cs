using System;

class Program
{
    static void Main()
    {
        int basicPay = 8000;
        int workingDays = 30;
        int output;

        
        if (basicPay < 0)
        {
            output = -1;
        }
        else if (basicPay > 10000)
        {
            output = -2;
        }
        else if (workingDays > 31)
        {
            output = -3;
        }
        else
        {
            int da = (basicPay * 75) / 100;
            int hra = (basicPay * 50) / 100;

            int grossSalary = basicPay + da + hra;
            output = grossSalary;
        }

        Console.WriteLine(output);
    }
}
