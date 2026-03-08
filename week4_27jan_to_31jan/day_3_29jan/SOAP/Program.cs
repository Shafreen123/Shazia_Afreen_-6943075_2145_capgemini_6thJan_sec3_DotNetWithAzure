using System;
using System.IO;
using System.Runtime.Serialization;

[DataContract]
public class Student
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        Student s = new Student { Id = 101, Name = "John Doe" };

        DataContractSerializer serializer =
            new DataContractSerializer(typeof(Student));

        // Serialize
        using (FileStream fs = new FileStream("student.xml", FileMode.Create))
        {
            serializer.WriteObject(fs, s);
        }

        // Deserialize
        using (FileStream fs = new FileStream("student.xml", FileMode.Open))
        {
            Student result = (Student)serializer.ReadObject(fs);
            Console.WriteLine($"Id: {result.Id}, Name: {result.Name}");
        }
    }
}
