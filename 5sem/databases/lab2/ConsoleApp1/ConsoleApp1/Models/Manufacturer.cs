using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Components = new HashSet<Component>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public virtual ICollection<Component> Components { get; set; }
    }
}
