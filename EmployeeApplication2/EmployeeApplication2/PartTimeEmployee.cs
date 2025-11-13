using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EmployeeApplication2
{
    public class PartTimeEmployee : EmployeeInterface
    {
        public PartTimeEmployee()
        {
            Console.WriteLine("--- Employee Salary Calculator ---");
        }
        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }
        public string Dept { get; set; }
        public string JobTitle { get; set; }
        public double RatePerHour { get; set; }
        public double HoursWorked { get; set; }

        public double ComputeSalary()
        {
            return RatePerHour * HoursWorked;
        }
    }    
}
