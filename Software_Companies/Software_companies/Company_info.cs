using System;

namespace Software_companies
{
    internal class Company_info
    {
        public string Founder;
        public int EstablishedYear;

        public void ShowInfo()
        {
            Console.WriteLine("Founder         : " + Founder);
            Console.WriteLine("Established Year: " + EstablishedYear);
        }
    }
}
