using System;
using System.Linq;

class Program
{
    static long MaxTotalStrength(int[] skills, int[] teamSizes)
    {
        Array.Sort(skills);
        Array.Sort(teamSizes);

        int left = 0;
        int right = skills.Length - 1;
        long totalStrength = 0;

        foreach (int size in teamSizes)
        {
            int maxSkill = skills[right];
            int minSkill = skills[left];

            totalStrength += maxSkill + minSkill;

            right--;                 
            left += size - 1;        
        }

        return totalStrength;
    }

    static void Main()
    {
        int[] skills = { 1, 3, 5, 7, 9, 11 };
        int[] teamSizes = { 2, 2, 2 };

        long result = MaxTotalStrength(skills, teamSizes);

        Console.WriteLine("Maximum Total Strength: " + result);
    }
}
