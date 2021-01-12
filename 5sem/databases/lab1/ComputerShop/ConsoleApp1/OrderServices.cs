using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class OrderServices
    {
        public int OrderServiceId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Services Service { get; set; }
    }
}
