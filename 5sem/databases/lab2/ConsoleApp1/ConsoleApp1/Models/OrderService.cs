using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class OrderService
    {
        public int OrderServiceId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
