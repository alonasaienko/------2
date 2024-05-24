using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public class Employee
{
    public string Name{get;set;}
    public string Position{get;set;}
    public DateTime HireDate{get;set;}
    public Employee(){}
    public Employee(string name, string position, DateTime date)
    {
        Name = name;
        Position = position;
        HireDate = date;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Position: {Position}, HireDate: {HireDate}";
    }
}

[Serializable]
public class Employees
{
    public List<Employee> employees = new List<Employee>();
    public void Add(Employee employee)
    {
        employees.Add(employee);
    }
    public void Print()
    {
        foreach(var elem in employees)
        {
            Console.WriteLine(elem);
        };
    }
    public void SortByDate()
    {
        employees = employees.OrderBy(employee => employee.HireDate).ToList();
    }
    public void PrintToFile(string filename)
    {
        if(File.Exists(filename))
        {
            using(StreamWriter sw = new StreamWriter(filename))
            {
                foreach(var elem in employees)
                {
                    sw.WriteLine(elem);
                }
            }
        }
    }
    public void Serialization(string filename)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
        using(FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fileStream, employees);
        }
    }
    public void DeSerialization(string filename)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
        using(StreamReader reader = new StreamReader(filename))
        {
            employees = (List<Employee>)xmlSerializer.Deserialize(reader);
        }
    }
}

class Program()
{
    public static void Main()
    {
        Employees employees = new Employees();
        string ReadXml = "./employees.xml";
        employees.Serialization(ReadXml);
        string fileToWrite = "./employees.txt";
        string sortedFile = "./sorted_employees.xml";

        employees.DeSerialization(ReadXml);
        employees.Print();


        Employee employee1 = new Employee("John Doe", "Manager", DateTime.Now);
        Employee employee2 = new Employee("Jane Smith", "Developer", DateTime.Now);
        Employee employee3 = new Employee("Albert Johnson", "Analyst", DateTime.Now);
        employees.Add(employee1);
        employees.Add(employee2);
        employees.Add(employee3);
        employees.Print();
        employees.Serialization(sortedFile);

        employees.SortByDate();
        employees.Serialization(sortedFile);
        employees.PrintToFile(fileToWrite);
    }
}

