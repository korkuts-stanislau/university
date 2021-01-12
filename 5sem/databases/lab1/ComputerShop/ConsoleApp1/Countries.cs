using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Countries
    {
        public Countries()
        {
            Components = new HashSet<Components>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Components> Components { get; set; }
    }
}
