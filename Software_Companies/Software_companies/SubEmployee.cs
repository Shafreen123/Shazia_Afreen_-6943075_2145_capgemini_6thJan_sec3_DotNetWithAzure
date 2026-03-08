using System;

namespace Software_companies
{
    internal class SubEmployee
    {// inheritance
        public int employeeId;
        public string trainerName;
        public string department;

        public void ShowTrainerDetails()
        {
            Console.WriteLine("Trainer Details");
            Console.WriteLine("---------------");
            Console.WriteLine("Trainer ID     : " + employeeId);
            Console.WriteLine("Trainer Name   : " + trainerName);
            Console.WriteLine("Department     : " + department);
        }
    }
   
        internal class Intern : SubEmployee
        {
            public int internId;
            public string internName;

            public void ShowInternDetails()
            {
                Console.WriteLine("Intern Details");
                Console.WriteLine("--------------");
                Console.WriteLine("Intern ID      : " + internId);
                Console.WriteLine("Intern Name    : " + internName);
                Console.WriteLine("Department     : " + department);
                Console.WriteLine("Trainer Name   : " + trainerName);
            }
        }
    
}
