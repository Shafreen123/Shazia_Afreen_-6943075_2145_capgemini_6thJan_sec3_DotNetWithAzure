using System;
using System.Numerics;


class Person
{
    public string Name { get; set; }
}

class Patient : Person
{
    public int PatientId { get; set; }
}

class Doctor : Person
{
    public string Specialization { get; set; }
}

class Nurse : Person { }

class Appointment
{
    public Patient patient;
    public Doctor doctor;
}

class Program
{
    static void Main(string[] args)
    {
        Patient p = new Patient();
        p.Name = "Rahul";
        p.PatientId = 101;

        Doctor d = new Doctor();
        d.Name = "Dr. Mehta";
        d.Specialization = "Cardiology";

        Console.WriteLine($"Patient: {p.Name}");
        Console.WriteLine($"Doctor: {d.Name}, Spec: {d.Specialization}");
    }
}
