using System;

namespace Software_companies
{
    interface ICompanyPolicy
    {
        void WorkHours();
        void LeavePolicy();
    }

    interface IEmployeeBenefits
    {
        void Salary();
        void Insurance();
    }

    // 🔁 RENAMED
    abstract class CompanyAbstract
    {
        public string CompanyName;

        public CompanyAbstract(string name)
        {
            CompanyName = name;
        }

        public abstract void CompanyType();

        public void CompanyLocation()
        {
            Console.WriteLine("Company Location: India");
        }
    }

    abstract class Employee
    {
        public abstract void EmployeeRole();

        public void EmployeeStatus()
        {
            Console.WriteLine("Employee Status: Permanent");
        }
    }

    // 🔁 Updated inheritance
    class SoftwareCompanyHD : CompanyAbstract, ICompanyPolicy, IEmployeeBenefits
    {
        public SoftwareCompanyHD(string name) : base(name) { }

        public override void CompanyType()
        {
            Console.WriteLine("Company Type: IT Services");
        }

        public void WorkHours()
        {
            Console.WriteLine("Work Hours: 9 AM - 6 PM");
        }

        public void LeavePolicy()
        {
            Console.WriteLine("Leave Policy: 20 Days Per Year");
        }

        public void Salary()
        {
            Console.WriteLine("Salary: 6 LPA");
        }

        public void Insurance()
        {
            Console.WriteLine("Insurance: Health + Life");
        }
    }

    class Developer : Employee
    {
        public override void EmployeeRole()
        {
            Console.WriteLine("Employee Role: Software Developer");
        }
    }
}
