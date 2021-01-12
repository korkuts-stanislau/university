using System;
using System.Collections.Generic;

namespace ComputerShop.WebUI.Models
{
    public class OrderComponent
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ComponentId { get; set; }

        public virtual Component Component { get; set; }
        public virtual Order Order { get; set; }
    }
}
