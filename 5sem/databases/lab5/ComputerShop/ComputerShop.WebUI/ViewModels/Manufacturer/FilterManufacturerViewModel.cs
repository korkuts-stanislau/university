using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Manufacturer
{
    public class FilterManufacturerViewModel
    {
        public string SelectedManufacturerName { get; set; }
        public FilterManufacturerViewModel(string selectedManufacturerName)
        {
            SelectedManufacturerName = selectedManufacturerName;
        }
    }
}
