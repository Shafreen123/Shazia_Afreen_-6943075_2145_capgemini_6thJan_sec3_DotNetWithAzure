using System;

namespace Software_companies
{
    struct CompanyAddress
    {
        public string City;
        public string State;

        public CompanyAddress(string city, string state)
        {
            City = city;
            State = state;
        }

        public void DisplayAddress()
        {
            Console.WriteLine("City  : " + City);
            Console.WriteLine("State : " + State);
        }
    }
}
