using ComputerShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Component
{
    public class FilterComponentViewModel
    {
        public SelectList ComponentTypes { get; set; }
        public int? SelectedComponentTypeId { get; set; }

        public SelectList Manufacturers { get; set; }
        public int? SelectedManufacturerId { get; set; }

        public SelectList Countries { get; set; }
        public int? SelectedCountryId { get; set; }

        public string SelectedModelName { get; set; }

        public FilterComponentViewModel(List<Models.ComponentType> componentTypes,
                                        List<Models.Manufacturer> manufacturers,
                                        List<Models.Country> countries,
                                        int? selectedComponentTypeId,
                                        int? selectedManufacturerId,
                                        int? selectedCountryId,
                                        string selectedModelName)
        {
            componentTypes.Insert(0, new Models.ComponentType { Id = 0, Name = "All" });
            manufacturers.Insert(0, new Models.Manufacturer { Id = 0, Name = "All" });
            countries.Insert(0, new Models.Country { Id = 0, Name = "All" });

            ComponentTypes = new SelectList(componentTypes, "Id", "Name", selectedComponentTypeId);
            SelectedComponentTypeId = selectedComponentTypeId;

            Manufacturers = new SelectList(manufacturers, "Id", "Name", selectedManufacturerId);
            SelectedManufacturerId = selectedManufacturerId;

            Countries = new SelectList(countries, "Id", "Name", selectedCountryId);
            SelectedCountryId = selectedCountryId;

            SelectedModelName = selectedModelName;
        }
    }
}
