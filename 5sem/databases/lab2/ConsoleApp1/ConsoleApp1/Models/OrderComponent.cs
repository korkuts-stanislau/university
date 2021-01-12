using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class OrderComponent
    {
        public int OrderComponentId { get; set; }
        public int OrderId { get; set; }
        public int ComponentId { get; set; }

        public virtual Component Component { get; set; }
        public virtual Order Order { get; set; }
    }
}
