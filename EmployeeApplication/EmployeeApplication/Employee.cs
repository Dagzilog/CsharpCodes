using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication
{
    public struct EmployeeInfo
    {
        private int employeeID;
        private string employeeFName;
        private string employeeLName;
        private string employeePosition;

        public EmployeeInfo(int employeeId, string employeeFName, string employeeLName, string employeePosition)
        {
            this.employeeID = employeeId;
            this.employeeFName = employeeFName;
            this.employeeLName = employeeLName;
            this.employeePosition = employeePosition; 
        }
        public EmployeeInfo(int employeeId, string employeeFName, string employeeLName)
       : this(employeeId, employeeFName, employeeLName, "Unassigned")
        { }
        public int EmployeeID { get { return employeeID; } set { this.employeeID = value; } }
        public string EmployeeFname { get { return employeeFName; } set { this.employeeFName = value; } }
        public string EmployeeLname { get { return employeeLName; } set { this.employeeLName = value; } }
        public string EmployeePosition { get { return employeePosition; } set { this.employeePosition = value; } }
        public void PrintInfo()
        {
            Console.WriteLine($"Employee ID: {employeeID}");
            Console.WriteLine($"First Name: {employeeFName}");
            Console.WriteLine($"Last Name: {employeeLName}");
            Console.WriteLine($"Position: {employeePosition}");
            Console.WriteLine();
        }
    }
    public class Employee
    {
        EmployeeInfo emp = new EmployeeInfo(2019001, "Jack", "Paul", "Supervisor");
        EmployeeInfo emp2 = new EmployeeInfo(20160005, "Erica", "Reyes", "Manager");
        EmployeeInfo emp3 = new EmployeeInfo(20210046, "Rudolf", "Cruz", "Staff");
        EmployeeInfo emp4 = new EmployeeInfo(20201004, "Christine", "Delos Reyes", "Staff");
        EmployeeInfo empOverloaded = new EmployeeInfo(20002891, "Romel Louis", "Daguiso");
        public void printInfos()
        {
            emp.PrintInfo();
            emp2.PrintInfo();
            emp3.PrintInfo();
            emp4.PrintInfo();
            empOverloaded.PrintInfo();
        }
    }
}

