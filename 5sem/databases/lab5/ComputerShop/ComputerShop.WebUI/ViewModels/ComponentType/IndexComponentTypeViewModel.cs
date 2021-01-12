using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.ComponentType
{
    public class IndexComponentTypeViewModel
    {
        public IEnumerable<Models.ComponentType> ComponentTypes { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterComponentTypeViewModel FilterComponentTypeViewModel { get; set; }
        public SortComponentTypeViewModel SortComponentTypeViewModel { get; set; }
    }
}
