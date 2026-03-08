using System;

namespace Software_companies
{
    internal class Program
    {  
        static void Main(string[] args)
        {
            try { 
            // --------- Companies_names class ----------
            Companies_names.DisplayDetails();

            Console.WriteLine();

            // --------- Company_info class ----------
            Company_info info = new Company_info();
            info.Founder = "N. R. Narayana Murthy";
            info.EstablishedYear = 1981;
            info.ShowInfo();

            Console.WriteLine();

            // --------- Inheritance example ----------
            Intern intern = new Intern();

            intern.employeeId = 1001;
            intern.trainerName = "Mr. Suresh";
            intern.department = "DotNet";

            intern.internId = 5001;
            intern.internName = "Shazia Afreen";

            Console.WriteLine();
            intern.ShowTrainerDetails();

            Console.WriteLine();
            intern.ShowInternDetails();
            // Override Example

            Console.WriteLine("---- Override Example ----");
            Company c1 = new SoftwareCompany("Infosys");
            c1.CompanyDomain();
            //Overload Example

            Console.WriteLine("\n---- Overwrite Example ----");
            Company c2 = new ProductCompany("Google");
            c2.CompanyPolicy();

            ProductCompany pc = new ProductCompany("Google");
            pc.CompanyPolicy();

            // interface and abstract class

            SoftwareCompanyHD company = new SoftwareCompanyHD("TechSoft");

            Console.WriteLine("---- Company Details ----");
            Console.WriteLine("Company Name: " + company.CompanyName);
            company.CompanyType();
            company.CompanyLocation();
            company.WorkHours();
            company.LeavePolicy();
            company.Salary();
            company.Insurance();

            Console.WriteLine("\n---- Employee Details ----");
            Developer dev = new Developer();
            dev.EmployeeRole();
            dev.EmployeeStatus();

            Console.WriteLine("\n---- Structure Example ----");
            CompanyAddress address = new CompanyAddress("Bangalore", "Karnataka");
            address.DisplayAddress();

                SoftwareCompany<string> company1 =
                new SoftwareCompany<string>(
                    "Infosys",
                    "N. R. Narayana Murthy",
                    1981,
                    Department.Development,
                    "Global IT Services Company"
                );

                company1.DisplayCompanyDetails();

                SoftwareCompany<int> company2 =
                new SoftwareCompany<int>(
                    "TCS",
                    "J. R. D. Tata",
                    1968,
                    Department.Finance,
                    500000 // number of employees
                );

                company2.DisplayCompanyDetails();

            }
         catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
    finally
    {
        Console.WriteLine("\nProgram execution completed.");
    }


            Console.ReadLine();

           
        }
    }
}
