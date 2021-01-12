using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Country
{
    public enum SortState
    {
        CountryNameAsc,
        CountryNameDesc
    }
    public class SortCountryViewModel
    {
        public SortState CountrySort;
        public SortState Current;

        public SortCountryViewModel(SortState sortOrder)
        {
            CountrySort = sortOrder == SortState.CountryNameAsc ? SortState.CountryNameDesc : SortState.CountryNameAsc;
            Current = sortOrder;
        }
    }
}
