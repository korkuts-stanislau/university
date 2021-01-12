using System;
using System.Collections.Generic;

namespace ComputerShop.WebUI.Models
{
    public class OrderService
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
