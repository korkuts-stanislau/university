using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Country
    {
        public Country()
        {
            Components = new HashSet<Component>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Component> Components { get; set; }
    }
}
