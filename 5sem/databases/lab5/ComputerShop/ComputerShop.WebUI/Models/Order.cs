using System;
using System.Collections.Generic;

namespace ComputerShop.WebUI.Models
{
    public class Order
    {
        public Order()
        {
            OrderComponents = new HashSet<OrderComponent>();
            OrderServices = new HashSet<OrderService>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Prepayment { get; set; }
        public bool IsPaid { get; set; }
        public bool IsFinished { get; set; }
        public int ExecutingEmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee ExecutingEmployee { get; set; }
        public virtual ICollection<OrderComponent> OrderComponents { get; set; }
        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
