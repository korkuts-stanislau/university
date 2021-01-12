using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Component
    {
        public Component()
        {
            OrderComponents = new HashSet<OrderComponent>();
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

        public virtual Country ComponentCountry { get; set; }
        public virtual Manufacturer ComponentManufacturer { get; set; }
        public virtual ComponentType ComponentType { get; set; }
        public virtual ICollection<OrderComponent> OrderComponents { get; set; }
    }
}
