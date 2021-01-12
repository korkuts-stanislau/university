using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Employees
    {
        public Employees()
        {
            Orders = new HashSet<Orders>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public int EmployeeWorkExperienceInMonth { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
