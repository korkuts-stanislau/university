using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Order
    {
        public Order()
        {
            OrderComponents = new HashSet<OrderComponent>();
            OrderServices = new HashSet<OrderService>();
        }

        public int OrderId { get; set; }
        public DateTime OrderStartDate { get; set; }
        public DateTime OrderExecutionDate { get; set; }
        public int OrderCustomerId { get; set; }
        public decimal OrderPrepayment { get; set; }
        public bool OrderPaid { get; set; }
        public bool OrderFinished { get; set; }
        public int OrderExecutingEmployeeId { get; set; }

        public virtual Customer OrderCustomer { get; set; }
        public virtual Employee OrderExecutingEmployee { get; set; }
        public virtual ICollection<OrderComponent> OrderComponents { get; set; }
        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
