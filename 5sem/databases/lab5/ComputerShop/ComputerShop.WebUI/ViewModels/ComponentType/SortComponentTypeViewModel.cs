using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.ComponentType
{
    public enum SortState
    {
        ComponentTypeNameAsc,
        ComponentTypeNameDesc
    }
    public class SortComponentTypeViewModel
    {
        public SortState ComponentTypeNameSort { get; set; }
        public SortState Current { get; set; }
        public SortComponentTypeViewModel(SortState sortOrder)
        {
            ComponentTypeNameSort = sortOrder == SortState.ComponentTypeNameAsc ? SortState.ComponentTypeNameDesc : SortState.ComponentTypeNameAsc;
            Current = sortOrder;
        }
    }
}
