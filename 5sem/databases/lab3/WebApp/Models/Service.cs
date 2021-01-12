using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Service
    {
        public Service()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
