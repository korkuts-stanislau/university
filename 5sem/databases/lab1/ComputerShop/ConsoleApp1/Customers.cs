using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int CustomerDiscount { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
