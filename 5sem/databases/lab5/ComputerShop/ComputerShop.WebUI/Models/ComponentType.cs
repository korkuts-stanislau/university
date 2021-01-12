using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerShop.WebUI.Models
{
    public class ComponentType
    {
        public ComponentType()
        {
            Components = new HashSet<Component>();
        }

        public int Id { get; set; }
        [DisplayName("Component type")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Component> Components { get; set; }
    }
}
