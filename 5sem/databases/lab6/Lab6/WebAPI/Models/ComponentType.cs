using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebAPI.Models
{
    public class ComponentType
    {
        public int Id { get; set; }
        [DisplayName("Component type")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
