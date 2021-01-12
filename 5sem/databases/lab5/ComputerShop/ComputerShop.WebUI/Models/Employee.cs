using System;
using System.Collections.Generic;

namespace ComputerShop.WebUI.Models
{
    public class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int WorkExperienceInMonths { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
