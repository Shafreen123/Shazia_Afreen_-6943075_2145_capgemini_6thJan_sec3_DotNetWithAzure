using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Gadget
    {

        public string Name;
        public string Brand;
        public int Price;


        public void SetDetails(string name, string brand, int price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }


        public void DisplayDetails()
        {
            Console.WriteLine("Gadget Name : " + Name);
            Console.WriteLine("Brand       : " + Brand);
            Console.WriteLine("Price       : ₹" + Price);
        }


        public void IsExpensive()
        {
            if (Price > 50000)
                Console.WriteLine("This is an expensive gadget.");
            else
                Console.WriteLine("This is an affordable gadget.");
        }


        public void ApplyDiscount(int discount)
        {
            Price = Price - discount;
            Console.WriteLine("Price after discount: ₹" + Price);
        }



        static void Main(string[] args)
        {

            Gadget g1 = new Gadget();

            g1.SetDetails("Smartphone", "Samsung", 60000);
            g1.DisplayDetails();
            g1.IsExpensive();
            g1.ApplyDiscount(5000);

            Console.ReadLine();
        }
    }
}