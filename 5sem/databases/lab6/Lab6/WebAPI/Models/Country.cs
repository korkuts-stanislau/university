using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        [DisplayName("Country")]
        public string Name { get; set; }
    }
}
