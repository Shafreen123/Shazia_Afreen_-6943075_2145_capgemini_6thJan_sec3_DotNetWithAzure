using System;
using System.Collections.Generic;
using System.Text;

namespace Software_companies
{
    internal class Company
    {
        public string CompanyName;

        public Company(string name)
        {
            CompanyName = name;
        }

        public virtual void CompanyDomain()
        {
            Console.WriteLine(CompanyName + " works in general IT services.");
        }

        public void CompanyPolicy()
        {
            Console.WriteLine(CompanyName + " follows standard company policies.");
        }
    }
    class SoftwareCompany : Company
    {
        public SoftwareCompany(string name) : base(name)
        {
        }

        public override void CompanyDomain()
        {
            Console.WriteLine(CompanyName + " develops software, web, and mobile applications.");
        }
    }
    class ProductCompany : Company
    {
        public ProductCompany(string name) : base(name)
        {
        }

        public new void CompanyPolicy()
        {
            Console.WriteLine(CompanyName + " follows product-based agile policies.");
        }
    }
    }
