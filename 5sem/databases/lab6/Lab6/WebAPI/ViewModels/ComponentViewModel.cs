using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }
        public int ComponentTypeId { get; set; }
        public string Model { get; set; }
        public int ManufacturerId { get; set; }
        public int CountryId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Characteristics { get; set; }
        public int WarrantyInMonths { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string CountryName { get; set; }
        public string ManufacturerName { get; set; }
        public string ComponentTypeName { get; set; }
    }
}
