using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class OrderComponents
    {
        public int OrderComponentId { get; set; }
        public int OrderId { get; set; }
        public int ComponentId { get; set; }

        public virtual Components Component { get; set; }
        public virtual Orders Order { get; set; }
    }
}
