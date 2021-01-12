using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class ComponentTypes
    {
        public ComponentTypes()
        {
            Components = new HashSet<Components>();
        }

        public int ComponentTypeId { get; set; }
        public string ComponentTypeName { get; set; }
        public string ComponentTypeDescription { get; set; }

        public virtual ICollection<Components> Components { get; set; }
    }
}
