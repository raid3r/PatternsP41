using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Structural;

public interface ICompanyElement
{
    List<ICompanyElement> Children { get; }
    void DisplayInfo(int indent = 0);
}


public class Manager: ICompanyElement {
    public string Name { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public List<ICompanyElement> Children { get; set; } = new List<ICompanyElement>();

    public void DisplayInfo(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + Name + ": manager");
        foreach (var child in Children)
        {
            child.DisplayInfo(indent + 2);
        }
    }
}

public class Employee: ICompanyElement {
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public List<ICompanyElement> Children { get; set; } = new List<ICompanyElement>();

    public void DisplayInfo(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + Name + " employee with salary: " + Salary);
    }
}   

public class Departament: ICompanyElement
{
    public string Name { get; set; }
    public List<ICompanyElement> Children { get; set; } = new List<ICompanyElement>();

    public void DisplayInfo(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + Name + " departament");
        foreach (var child in Children)
        {
            child.DisplayInfo(indent + 2);
        }
    }
}

public class Company: ICompanyElement
{
    public string Name { get; set; }
    public List<ICompanyElement> Children { get; set; } = new List<ICompanyElement>();

    public void DisplayInfo(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + Name);
        foreach (var child in Children)
        {
            child.DisplayInfo(indent + 2);
        }
    }
}

public class CompositeExampleClientCode
{
    public void Run()
    {
        var company = new Company { Name = "TechCorp" };

        var director = new Manager { Name = "John Smith" };
        company.Children.Add(director);

        var deputyDirector1 = new Manager { Name = "Alice Johnson" };
        var deputyDirector2 = new Manager { Name = "Bob Brown" };

        director.Children.Add(deputyDirector1);
        director.Children.Add(deputyDirector2);

        var department1 = new Departament { Name = "Development" };
        var department2 = new Departament { Name = "Marketing" };
        var department3 = new Departament { Name = "Sales" };

        deputyDirector1.Children.Add(department1);
        deputyDirector1.Children.Add(department2);

        deputyDirector2.Children.Add(department3);


        var employee1 = new Employee { Name = "Emily Davis", Salary = 60000 };
        var employee2 = new Employee { Name = "Michael Wilson", Salary = 55000 };
        var employee3 = new Employee { Name = "Sarah Miller", Salary = 50000 };
        var employee4 = new Employee { Name = "David Anderson", Salary = 45000 };

        department1.Children.Add(employee1);
        department1.Children.Add(employee2);

        department2.Children.Add(employee3);
        department3.Children.Add(employee4);




        company.DisplayInfo();

        //department1.DisplayInfo();



        //var company = new Company { Name = "TechCorp" };
        //var director = new Manager { Name = "John Smith" };
        //var deputyDirector1 = new Manager { Name = "Alice Johnson" };
        //var deputyDirector2 = new Manager { Name = "Bob Brown" };
        //var department1 = new Departament { Name = "Development" };
        //var department2 = new Departament { Name = "Marketing" };
        //var department3 = new Departament { Name = "Sales" };
        //var employee1 = new Employee { Name = "Emily Davis", Salary = 60000 };
        //var employee2 = new Employee { Name = "Michael Wilson", Salary = 55000 };
        //var employee3 = new Employee { Name = "Sarah Miller", Salary = 50000 };
        //var employee4 = new Employee { Name = "David Anderson", Salary = 45000 };
        // Here you can build the organizational structure using the composite pattern
    }
}

/*
 * Компанія
 *   Директор
 *     Заступник директора
 *       Відділ 1
 *          Співробітник 1
 *          Співробітник 2
 *       Відділ 2
 *           Співробітник 3
 *      Заступник директора
 *       Відділ 3
 *           Співробітник 4
 *   
 * 
 * 
 */

