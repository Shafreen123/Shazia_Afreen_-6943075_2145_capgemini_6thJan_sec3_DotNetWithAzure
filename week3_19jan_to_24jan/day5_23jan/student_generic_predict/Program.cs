using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<int, int> studentGrades = new Dictionary<int, int>
        {
            { 101, 85 },
            { 102, 40 },
            { 103, 72 },
            { 104, 35 }
        };

        Func<Dictionary<int, int>, double> averageGrade =
            grades => grades.Values.Average();

        Console.WriteLine("Average Grade: " + averageGrade(studentGrades));

      
        int threshold = 50;
        Predicate<int> isAtRisk = grade => grade < threshold;

        Console.WriteLine("\nStudents at Risk:");
        foreach (var student in studentGrades)
        {
            if (isAtRisk(student.Value))
                Console.WriteLine("Roll No: " + student.Key);
        }

        
        Console.WriteLine("\nUpdating grade for Roll No 102...");
        studentGrades[102] = 60;

       
        Console.WriteLine("Re-evaluated At-Risk Students:");
        foreach (var student in studentGrades)
        {
            if (isAtRisk(student.Value))
                Console.WriteLine("Roll No: " + student.Key);
        }
    }
}
