using System;

class Vehicle
{
    public string VehicleNo { get; set; }
    public double RentPerDay { get; set; }

    public virtual double CalculateRent(int days)
    {
        return days * RentPerDay;
    }
}

class Car : Vehicle { }
class Bike : Vehicle { }
class Truck : Vehicle { }

class Customer
{
    public string Name { get; set; }
}

class RentalTransaction
{
    public Vehicle vehicle;
    public int Days;

    public void ShowBill()
    {
        Console.WriteLine("Total Rent: " + vehicle.CalculateRent(Days));
    }
}


class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        car.VehicleNo = "CAR123";
        car.RentPerDay = 1000;

        RentalTransaction rt = new RentalTransaction();
        rt.vehicle = car;
        rt.Days = 3;

        rt.ShowBill();
    }
}
