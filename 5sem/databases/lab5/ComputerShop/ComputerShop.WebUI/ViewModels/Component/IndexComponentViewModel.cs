using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.Component
{
    public class IndexComponentViewModel
    {
        public IEnumerable<Models.Component> Components { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterComponentViewModel FilterComponentViewModel { get; set; }
        public SortComponentViewModel SortComponentViewModel { get; set; }
    }
}
