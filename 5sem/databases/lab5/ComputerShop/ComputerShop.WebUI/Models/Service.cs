using System;
using System.Collections.Generic;

namespace ComputerShop.WebUI.Models
{
    public class Service
    {
        public Service()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
