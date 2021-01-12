using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Orders
    {
        public Orders()
        {
            OrderComponents = new HashSet<OrderComponents>();
            OrderServices = new HashSet<OrderServices>();
        }

        public int OrderId { get; set; }
        public DateTime OrderStartDate { get; set; }
        public DateTime OrderExecutionDate { get; set; }
        public int OrderCustomerId { get; set; }
        public decimal OrderPrepayment { get; set; }
        public bool OrderPaid { get; set; }
        public bool OrderFinished { get; set; }
        public int OrderExecutingEmployeeId { get; set; }

        public virtual Customers OrderCustomer { get; set; }
        public virtual Employees OrderExecutingEmployee { get; set; }
        public virtual ICollection<OrderComponents> OrderComponents { get; set; }
        public virtual ICollection<OrderServices> OrderServices { get; set; }
    }
}
