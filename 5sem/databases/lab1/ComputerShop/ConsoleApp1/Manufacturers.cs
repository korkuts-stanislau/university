using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Components = new HashSet<Components>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public virtual ICollection<Components> Components { get; set; }
    }
}
