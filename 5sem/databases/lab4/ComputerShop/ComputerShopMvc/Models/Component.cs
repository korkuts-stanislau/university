using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShopMvc.Models
{
    public class Component
    {
        public int ComponentId { get; set; }
        public string ComponentModel { get; set; }
        public DateTime ComponentReleaseDate { get; set; }
        public string ComponentCharacteristics { get; set; }
        public int ComponentWarrantyPeriodInMonths { get; set; }
        public string ComponentDescription { get; set; }
        public decimal ComponentPrice { get; set; }

        public int ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
