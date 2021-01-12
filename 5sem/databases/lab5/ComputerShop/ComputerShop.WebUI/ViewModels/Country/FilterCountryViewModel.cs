using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Country
{
    public class FilterCountryViewModel
    {
        public string SelectedCountryName { get; set; }

        public FilterCountryViewModel(string selectedCountryName)
        {
            SelectedCountryName = selectedCountryName;
        }
    }
}
