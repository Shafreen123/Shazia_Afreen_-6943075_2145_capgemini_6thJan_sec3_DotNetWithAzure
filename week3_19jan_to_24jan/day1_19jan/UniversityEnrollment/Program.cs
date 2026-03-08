using System;

class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
}

class Student : Person
{
    public string Course { get; set; }
}

class Professor : Person
{
    public string Subject { get; set; }
}

class Staff : Person
{
    public string Department { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        Student s = new Student();
        s.Name = "Ayesha";
        s.Id = 1;
        s.Course = "Computer Science";

        Professor p = new Professor();
        p.Name = "Dr. Kumar";
        p.Subject = "OOPS";

        Console.WriteLine($"Student: {s.Name}, Course: {s.Course}");
        Console.WriteLine($"Professor: {p.Name}, Subject: {p.Subject}");
    }
}