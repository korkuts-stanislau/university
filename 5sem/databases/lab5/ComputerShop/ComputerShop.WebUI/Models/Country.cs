using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerShop.WebUI.Models
{
    public class Country
    {
        public Country()
        {
            Components = new HashSet<Component>();
        }

        public int Id { get; set; }
        [DisplayName("Country")]
        public string Name { get; set; }

        public virtual ICollection<Component> Components { get; set; }
    }
}
