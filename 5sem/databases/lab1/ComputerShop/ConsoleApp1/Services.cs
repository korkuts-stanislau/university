using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Services
    {
        public Services()
        {
            OrderServices = new HashSet<OrderServices>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }

        public virtual ICollection<OrderServices> OrderServices { get; set; }
    }
}
