using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerShop.WebUI.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Components = new HashSet<Component>();
        }

        public int Id { get; set; }
        [DisplayName("Manufacturer")]
        public string Name { get; set; }

        public virtual ICollection<Component> Components { get; set; }
    }
}
