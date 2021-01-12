using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.WebUI.Models
{
    public class Component
    {
        public Component()
        {
            OrderComponents = new HashSet<OrderComponent>();
        }

        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select component type")]
        public int ComponentTypeId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Model name length must be in range from 5 to 100")]
        [DisplayName("Model")]
        public string Model { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select manufacturer")]
        public int ManufacturerId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select country")]
        public int CountryId { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Characteristics length must be in range from 10 to 200")]
        [DisplayName("Characteristics")]
        public string Characteristics { get; set; }
        [Required]
        [Range(0, 360, ErrorMessage = "Warranty must be in range from 1 to 360")]
        [DisplayName("Warranty in months")]
        public int WarrantyInMonths { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description length must be in range from 10 to 200")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [Range(0, 1000000, ErrorMessage = "Warranty must be in range from 1 to 1000000")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        public virtual Country Country { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ComponentType ComponentType { get; set; }
        public virtual ICollection<OrderComponent> OrderComponents { get; set; }
    }
}
