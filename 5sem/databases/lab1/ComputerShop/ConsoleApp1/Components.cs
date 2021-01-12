using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Components
    {
        public Components()
        {
            OrderComponents = new HashSet<OrderComponents>();
        }

        public int ComponentId { get; set; }
        public int ComponentTypeId { get; set; }
        public string ComponentModel { get; set; }
        public int ComponentManufacturerId { get; set; }
        public int ComponentCountryId { get; set; }
        public DateTime ComponentReleaseDate { get; set; }
        public string ComponentCharacteristics { get; set; }
        public int ComponentWarrantyInMonths { get; set; }
        public string ComponentDescription { get; set; }
        public decimal ComponentPrice { get; set; }

        public virtual Countries ComponentCountry { get; set; }
        public virtual Manufacturers ComponentManufacturer { get; set; }
        public virtual ComponentTypes ComponentType { get; set; }
        public virtual ICollection<OrderComponents> OrderComponents { get; set; }
    }
}
