using EmployeeApplication2;
using System;
using System.Threading.Channels;

namespace EmployeeNameSpace
{
    class EmployeeMain
    {
        public static void Main(string[] args)
        {
            PartTimeEmployee emp = new PartTimeEmployee();

            Console.Write("Enter Employee First Name: ");
            emp.EmployeeFName = Console.ReadLine();

            Console.Write("Enter Employee Last Name: ");
            emp.EmployeeLName = Console.ReadLine();

            Console.Write("Enter Employee Department: ");
            emp.Dept = Console.ReadLine();

            Console.Write("Enter Employee Job Title: ");
            emp.JobTitle = Console.ReadLine();


            Console.Write("Enter Rate per Hour: ");
            emp.RatePerHour = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Hours Worked: ");
            emp.HoursWorked = Convert.ToDouble(Console.ReadLine());

            double salary = emp.ComputeSalary();

            Console.WriteLine("\n=== Employee Information ===");
            Console.WriteLine("Employee First Name: " + emp.EmployeeFName);
            Console.WriteLine("Employee Last Name: " + emp.EmployeeLName);
            Console.WriteLine("Employee Department: " + emp.Dept);
            Console.WriteLine("Employee Job Title: " + emp.JobTitle);
            Console.WriteLine("Rate per Hour: " + emp.RatePerHour);
            Console.WriteLine("Hours Worked: " + emp.HoursWorked);
            Console.WriteLine("Computed Salary: " + salary.ToString("C2"));

            Console.ReadKey();
        }
    }
}