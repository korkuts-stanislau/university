using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class GetAllComponentsInfo
    {
        public string ComponentTypeName { get; set; }
        public string ComponentTypeDescription { get; set; }
        public string ComponentModel { get; set; }
        public string ManufacturerName { get; set; }
        public string CountryName { get; set; }
        public DateTime ComponentReleaseDate { get; set; }
        public string ComponentCharacteristics { get; set; }
        public int ComponentWarrantyInMonths { get; set; }
        public string ComponentDescription { get; set; }
        public decimal ComponentPrice { get; set; }
    }
}
