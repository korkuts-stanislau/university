using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public int EmployeeWorkExperienceInMonth { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
