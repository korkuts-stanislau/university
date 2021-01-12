using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Manufacturer
{
    public enum SortState
    {
        ManufacturerNameAsc,
        ManufacturerNameDesc
    }
    public class SortManufacturerViewModel
    {
        public SortState ManufacturerSort { get; set; }
        public SortState Current { get; set; }
        public SortManufacturerViewModel(SortState sortOrder)
        {
            ManufacturerSort = sortOrder == SortState.ManufacturerNameAsc ? SortState.ManufacturerNameDesc : SortState.ManufacturerNameAsc;
            Current = sortOrder;
        }
    }
}
