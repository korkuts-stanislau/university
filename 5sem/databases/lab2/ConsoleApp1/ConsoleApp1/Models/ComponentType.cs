using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class ComponentType
    {
        public ComponentType()
        {
            Components = new HashSet<Component>();
        }

        public int ComponentTypeId { get; set; }
        public string ComponentTypeName { get; set; }
        public string ComponentTypeDescription { get; set; }

        public virtual ICollection<Component> Components { get; set; }
    }
}
