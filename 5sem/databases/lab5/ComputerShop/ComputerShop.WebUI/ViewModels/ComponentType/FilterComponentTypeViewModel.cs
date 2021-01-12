using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.WebUI.ViewModels.ComponentType
{
    public class FilterComponentTypeViewModel
    {
        public string SelectedComponentTypeName { get; set; }
        public FilterComponentTypeViewModel(string selectedComponentTypeName)
        {
            SelectedComponentTypeName = selectedComponentTypeName;
        }
    }
}
