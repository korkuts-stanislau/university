using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int CustomerDiscount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"Заказчик. Имя {CustomerFullName}, Адресc {CustomerAddress}, " +
                $"Номер телефона {CustomerPhoneNumber}, Скидка {CustomerDiscount}.";
        }
    }
}
