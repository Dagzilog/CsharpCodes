    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace EmployeeApplication2
    {
        public interface EmployeeInterface
        {
            string EmployeeFName { get; set; }
            string EmployeeLName { get; set; }
            string Dept { get; set; }
            string JobTitle { get; set; }
            double RatePerHour { get; set; }
            double HoursWorked { get; set; }
            double ComputeSalary();

        }
    }
