using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebAPI.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [DisplayName("Manufacturer")]
        public string Name { get; set; }
    }
}
