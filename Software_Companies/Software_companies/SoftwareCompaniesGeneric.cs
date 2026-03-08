using System;

namespace Software_companies
{
    
    enum Department
    {
        Development,
        Testing,
        HR,
        Finance,
        Support
    }

   
    class SoftwareCompany<T>
    {
        
        public string CompanyName { get; set; }
        public string Founder { get; set; }
        public int EstablishedYear { get; set; }

     
        public Department CompanyDepartment { get; set; }

        
        public T CompanyData { get; set; }

      
        public SoftwareCompany(
            string companyName,
            string founder,
            int establishedYear,
            Department department,
            T data)
        {
            CompanyName = companyName;
            Founder = founder;
            EstablishedYear = establishedYear;
            CompanyDepartment = department;
            CompanyData = data;
        }

       
        public void DisplayCompanyDetails()
        {
            Console.WriteLine("----- Software Company Details -----");
            Console.WriteLine("Company Name     : " + CompanyName);
            Console.WriteLine("Founder          : " + Founder);
            Console.WriteLine("Established Year : " + EstablishedYear);
            Console.WriteLine("Department       : " + CompanyDepartment);
            Console.WriteLine("Generic Data     : " + CompanyData);
            Console.WriteLine("-----------------------------------");
        }
    }
}
