using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Country
{
    public class IndexCountryViewModel
    {
        public IEnumerable<Models.Country> Countries { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterCountryViewModel FilterCountryViewModel { get; set; }
        public SortCountryViewModel SortCountryViewModel { get; set; }
    }
}
