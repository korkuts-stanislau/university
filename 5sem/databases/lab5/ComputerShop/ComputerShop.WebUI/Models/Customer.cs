using System;
using System.Collections.Generic;

namespace ComputerShop.WebUI.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Discount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
