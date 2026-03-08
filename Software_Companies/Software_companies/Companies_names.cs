using System;

namespace Software_companies
{
    internal class Companies_names
    { //different type of variable
        public const string Country = "India";          // constant
        public static string CompanyType = "IT Services"; // static
        public int CompanyId;                            // instance
        public readonly string CompanyName;              // readonly

        public Companies_names(int id, string name)
        {
            CompanyId = id;
            CompanyName = name;
        }

        public static void DisplayDetails()
        {
            Companies_names c = new Companies_names(101, "Infosys");

            Console.WriteLine("Company ID   : " + c.CompanyId);
            Console.WriteLine("Company Name : " + c.CompanyName);
            Console.WriteLine("Company Type : " + CompanyType);
            Console.WriteLine("Country      : " + Country);
        }
    }
}
